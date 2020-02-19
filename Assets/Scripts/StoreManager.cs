using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {

    public GameObject general;
    public GameObject platform;
    public GameObject carOptions;
    public GameObject details;

	// Use this for initialization
	void Awake ()
    {
        AnalyticsEvent.StoreOpened(StoreType.Soft);
    }

    void Start()
    {
        general = GameObject.Find("General");
        platform = GameObject.Find("CarPlatform");
        carOptions = GameObject.Find("CarOptions");
        details = GameObject.Find("CarDetails + Upgrades");

        platform.SetActive(false);
        details.SetActive(false);
    }

    public void Back()
    {
        AnalyticsEvent.ScreenVisit(ScreenName.MainMenu);
        PlayerPrefs.SetString("Load", "Main Menu");
        SceneManager.LoadSceneAsync("Load");
    }

    public void Mustang()
    {
        platform.SetActive(true);
        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarPicked", "Mustang");
    }
}