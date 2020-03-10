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

    private AudioSource music;
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
        music = GameObject.Find("Music").GetComponent<AudioSource>();

        if(PlayerPrefs.GetString("Logged In") == "Yes")
        {
            loginCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
            playerID = PlayerPrefs.GetInt("Player ID");
            //Debug.Log(PlayerPrefs.GetInt("Player ID"));
        }
        else
        {
            mainMenuCanvas.SetActive(false);
            loginCanvas.SetActive(true);
        }

        Debug.Log(PlayerPrefs.GetInt("Money"));
    }

    public void Play()
    {
        Debug.Log(playerID);

        int timesPressed = PlayerPrefs.GetInt("TimesPlayed");

        AnalyticsEvent.Custom("game_play", new Dictionary<string, object>
        {
            { "PlayerID ", playerID }
        });

        timesPressed++;
        PlayerPrefs.SetInt("TimesPlayed", timesPressed);

        PlayerPrefs.SetString("Load", "Lake Race");
        SceneManager.LoadSceneAsync("Load");
    }

    public void Store()
    {
        AnalyticsEvent.Custom("opened_store", new Dictionary<string, object>
        {
            { "PlayerID", playerID}
        });

        //DontDestroyOnLoad(music);

        PlayerPrefs.SetString("Load", "Store");
        SceneManager.LoadSceneAsync("Load");
    }

    public void Scoreboard()
    {
        AnalyticsEvent.ScreenVisit(ScreenName.Leaderboard);

        PlayerPrefs.SetString("Load", "Scoreboard");
        SceneManager.LoadSceneAsync("Load");
    }

    public void QuitGame()
    {
        AnalyticsEvent.Custom("quit", new Dictionary<string, object>
        {
            { "PlayerID", playerID}
        });

        PlayerPrefs.DeleteKey("Logged In");

        PlayerPrefs.SetString("MustangOwned", "YES");
        PlayerPrefs.SetString("CarChosen", "Mustang");
        PlayerPrefs.SetInt("Money", 40000);

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
