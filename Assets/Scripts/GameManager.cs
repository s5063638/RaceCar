using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject lapController;
    public GameObject car;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lapText;
    public TextMeshProUGUI countDownText;

    public int numOfLaps;
    public int currentLap;
    public float timer;
    public float startTime;
    public bool racing;

    void Awake()
    {
        AnalyticsEvent.LevelStart("Lake Race");
    }

	// Use this for initialization
	void Start ()
    {
        lapController = GameObject.FindGameObjectWithTag("Finish");
        car = GameObject.FindGameObjectWithTag("Car");
        numOfLaps = 3;
        currentLap = 1;
        racing = false;
        timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
        lapText = GameObject.FindGameObjectWithTag("Laps").GetComponent<TextMeshProUGUI>();
        countDownText = GameObject.FindGameObjectWithTag("Count").GetComponent<TextMeshProUGUI>();

        StartCoroutine(StartRace());
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(racing)
        {
            timer = Time.time - startTime;

            string mins = Mathf.Floor(timer / 60).ToString("00");
            string secs = Mathf.Floor(timer % 60).ToString("00");

            timerText.text = mins + ":" + secs;
            lapText.text = "Lap " + currentLap + "/" + numOfLaps;
        }
	}

    public void Laps()
    {
        if(currentLap < numOfLaps)
        {
            currentLap++;
            Debug.Log("Current Lap: " + currentLap);
            Debug.Log("Number of laps: " + numOfLaps);
        }
        else
        {
            car.GetComponent<CarScript>().canMove = false;
            racing = false;

            //Trigger the end of the race here
            countDownText.text = "Finished";
            StartCoroutine(RaceEnd());
        }
    }

    IEnumerator StartRace()
    {
        lapController.SetActive(false);
        countDownText.text = "3";
        yield return new WaitForSeconds(1.0f);
        countDownText.text = "2";
        yield return new WaitForSeconds(1.0f);
        countDownText.text = "1";
        yield return new WaitForSeconds(1.0f);
        countDownText.text = "GO";
        car.GetComponent<CarScript>().canMove = true;
        startTime = Time.time;
        racing = true;
        yield return new WaitForSeconds(1.0f);
        countDownText.text = "";
    }

    IEnumerator RaceEnd()
    {
        yield return new WaitForSeconds(2.0f);
        AnalyticsEvent.LevelComplete("Lake Race");

        PlayerPrefs.SetString("Load", "Scoreboard");
        SceneManager.LoadSceneAsync("Load");
    }
}
