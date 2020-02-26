using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    private GameObject mainMenuCanvas;
    private GameObject loginCanvas;
    private GameObject inputField;

    private int playerID;

    void Awake()
    {
        //AnalyticsResult result = Analytics.CustomEvent("Test");
        //Debug.Log(result);
        AnalyticsEvent.GameStart();
    }

    void Start()
    {
        mainMenuCanvas = GameObject.Find("MainMenuCanvas");
        loginCanvas = GameObject.Find("LoginCanvas");
        inputField = GameObject.FindGameObjectWithTag("Input");

        if(PlayerPrefs.GetString("Logged In") == "Yes")
        {
            loginCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
            //Debug.Log(PlayerPrefs.GetInt("Player ID"));
        }
        else
        {
            mainMenuCanvas.SetActive(false);
            loginCanvas.SetActive(true);
        }
    }

    public void Play()
    {
        PlayerPrefs.SetString("Load", "Lake Race");
        SceneManager.LoadSceneAsync("Load");
    }

    public void Store()
    {
        PlayerPrefs.SetString("Load", "Store");
        SceneManager.LoadSceneAsync("Load");
    }

    public void Scoreboard()
    {
        AnalyticsEvent.Custom("OpenedStore", null);

        AnalyticsEvent.ScreenVisit(ScreenName.Leaderboard);

        PlayerPrefs.SetString("Load", "Scoreboard");
        SceneManager.LoadSceneAsync("Load");
    }

    public void QuitGame()
    {
        AnalyticsEvent.Custom("Quit", null);
        AnalyticsEvent.GameOver();
        Application.Quit();
    }

    public void SignIn()
    {
        if(inputField.GetComponent<InputField>().text != "")
        {
            PlayerPrefs.SetInt("Player ID", int.Parse(inputField.GetComponent<InputField>().text));

            PlayerPrefs.SetString("Logged In", "Yes");

            playerID = PlayerPrefs.GetInt("Player ID");

            loginCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
        }
    }
}
