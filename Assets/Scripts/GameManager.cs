﻿using System.Collections;
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

    private GameObject lap2Obstacles;
    private GameObject lap3Obstacles;

    private CameraFollow camFollow;

    private int playerID;
    void Awake()
    {
        AnalyticsEvent.LevelStart("Lake Race");
    }

	// Use this for initialization
	void Start ()
    {
        lapController = GameObject.FindGameObjectWithTag("Finish");
        numOfLaps = 3;
        currentLap = 1;
        racing = false;
        timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
        lapText = GameObject.FindGameObjectWithTag("Laps").GetComponent<TextMeshProUGUI>();
        countDownText = GameObject.FindGameObjectWithTag("Count").GetComponent<TextMeshProUGUI>();
        camFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();

        lap2Obstacles = GameObject.Find("Lap 2");
        lap3Obstacles = GameObject.Find("Lap 3");

        lap2Obstacles.SetActive(false);
        lap3Obstacles.SetActive(false);

        playerID = PlayerPrefs.GetInt("Player ID");

        StartCoroutine(SetCar());
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

        if(currentLap == 2)
        {
            lap2Obstacles.SetActive(true);
        }
        else if(currentLap == 3)
        {
            lap3Obstacles.SetActive(true);
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
        yield return new WaitForSeconds(0.5f);
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

        switch (PlayerPrefs.GetInt("Player ID"))
        {
            case 1:
            {
                PlayerPrefs.SetFloat("Time taken for " + 1, timer);
                break;
            }
            case 2:
            {
                PlayerPrefs.SetFloat("Time taken for " + 2, timer);
                break;
            }
            case 3:
            {
                 PlayerPrefs.SetFloat("Time taken for " + 3, timer);
                 break;
            }
            case 4:
            {
                PlayerPrefs.SetFloat("Time taken for " + 4, timer);
                break;
            }
            case 5:
            {
                PlayerPrefs.SetFloat("Time taken for " + 5, timer);
                break;
            }
            case 6:
            {
                PlayerPrefs.SetFloat("Time taken for " + 6, timer);
                break;
            }
            case 7:
            {
                PlayerPrefs.SetFloat("Time taken for " + 7, timer);
                break;
            }
            case 8:
            {
                PlayerPrefs.SetFloat("Time taken for " + 8, timer);
                break;
            }
            case 9:
            {
                PlayerPrefs.SetFloat("Time taken for " + 9, timer);
                break;
            }
            case 10:
            {
                PlayerPrefs.SetFloat("Time taken for " + 10, timer);
                break;
            }
        }
        
        PlayerPrefs.SetString("Load", "Scoreboard");
        SceneManager.LoadSceneAsync("Load");
    }

    IEnumerator SetCar()
    {
        yield return new WaitForSeconds(0.5f);
        car = GameObject.FindGameObjectWithTag("Car");
        camFollow.parentRigidbody = car.GetComponent<Rigidbody>();
        camFollow.target = car.transform;
    }
}
