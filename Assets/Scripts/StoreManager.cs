using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour {

    public GameObject general;
    public GameObject mustangCar;
    public GameObject demonCar;
    public GameObject chrysterCar;
    public GameObject audoCar;
    public GameObject hotrodCar;
    public GameObject carOptions;
    public GameObject details;
    public GameObject myMoney;

    private StoreCarDetails carDetails;

	// Use this for initialization
	void Awake ()
    {
        AnalyticsEvent.StoreOpened(StoreType.Soft);
    }

    void Start()
    {
        general = GameObject.Find("General");
        demonCar = GameObject.Find("DemonCarPlatform");
        mustangCar = GameObject.Find("MustangCarPlatform");
        chrysterCar = GameObject.Find("ChrysterCarPlatform");
        audoCar = GameObject.Find("AudoCarPlatform");
        hotrodCar = GameObject.Find("HotrodCarPlatform");
        carOptions = GameObject.Find("CarOptions");
        details = GameObject.Find("CarDetails + Upgrades");
        myMoney = GameObject.FindWithTag("Money");

        carDetails = details.GetComponent<StoreCarDetails>();

        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        details.SetActive(false);

        myMoney.GetComponent<TextMeshProUGUI>().text = "My Money: $" + PlayerPrefs.GetInt("Money").ToString();
    }

    public void Buy()
    {
        //Insert stuff about buying here
    }

    public void Back()
    {
        AnalyticsEvent.ScreenVisit(ScreenName.MainMenu);
        PlayerPrefs.SetString("Load", "Main Menu");
        SceneManager.LoadSceneAsync("Load");
    }

    public void DetailsBack()
    {
        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        details.SetActive(false);
        general.SetActive(true);
        carOptions.SetActive(true);
    }

    public void Mustang()
    {
        demonCar.SetActive(false);
        mustangCar.SetActive(true);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarViewed", "Mustang");
        carDetails.UpdateCar();
    }

    public void Demon()
    {
        demonCar.SetActive(true);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarViewed", "Demon");
        carDetails.UpdateCar();
    }

    public void Chryster()
    {
        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(true);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarViewed", "Chryster");
        carDetails.UpdateCar();
    }

    public void Audo()
    {
        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(true);
        hotrodCar.SetActive(false);

        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarViewed", "Audo");
        carDetails.UpdateCar();
    }

    public void HotRod()
    {
        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(true);

        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarViewed", "Hotrod");
        carDetails.UpdateCar();
    }
}