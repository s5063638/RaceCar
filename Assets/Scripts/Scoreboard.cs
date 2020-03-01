using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Scoreboard : MonoBehaviour {

    Dictionary<string, float> userScores;

    int changeCounter = 0;

    void Start()
    {

    }

    void Init()
    {
        if (userScores != null)
        {
            Debug.Log("Not Null");
            return;
        }

        userScores = new Dictionary<string, float>();
    }

    public void Reset()
    {
        changeCounter++;
        userScores = null;
    }

    public float GetScore(string iD)
    {
        Init();

        if(userScores.ContainsKey(iD) == false)
        {
            return 0;
        }

        return userScores[iD];
    }

    public void SetScore(string iD, float value)
    {
        Init();
        changeCounter++;
        userScores[iD] = value;
    }

    public string[] GetPlayerNames()
    {
        Init();
        return userScores.Keys.ToArray();
    }

    //public string[] GetPlayerNames()
    //{
    //    Init();
    //    return userScores.Keys.OrderByDescending(n => GetScore(n)).ToArray();
    //}

    public int GetChangeCounter()
    {
        return changeCounter;
    }

	public void Back()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void DEBUG_INITIAL_SETUP()
    {
        SetScore("001", 5.0f);
        SetScore("002", 6.25f);
        SetScore("003", 4.59f);
        SetScore("004", 2.00f);
    }
}
