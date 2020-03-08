using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Scoreboard : MonoBehaviour {

    Dictionary<string, float> userScores;

    int changeCounter = 0;

    List<KeyValuePair<string, float>> orderedList;

    void Start()
    {
        float time = 0.0f;
        string player = "";

        for (int i = 1; i <= 10; i++)
        {
            switch(i)
            {
                case 1:
                {
                    time = PlayerPrefs.GetFloat("Time taken for " + 1);
                    player = i.ToString();
                    break;
                }
                case 2:
                {
                    time = PlayerPrefs.GetFloat("Time taken for " + 2);
                    player = i.ToString();
                    break;
                }
                case 3:
                {
                    time = PlayerPrefs.GetFloat("Time taken for " + 3);
                    player = i.ToString();
                    break;
                }
                case 4:
                {
                    time = PlayerPrefs.GetFloat("Time taken for " + 4);
                    player = i.ToString();
                    break;
                }
                case 5:
                {
                    time = PlayerPrefs.GetFloat("Time taken for " + 5);
                    player = i.ToString();
                    break;
                }
                case 6:
                {
                    time = PlayerPrefs.GetFloat("Time taken for " + 6);
                    player = i.ToString();
                    break;
                }
                case 7:
                {
                    time = PlayerPrefs.GetFloat("Time taken for " + 7);
                    player = i.ToString();
                    break;
                }
                case 8:
                {
                    time = PlayerPrefs.GetFloat("Time taken for " + 8);
                    player = i.ToString();
                    break;
                }
                case 9:
                {
                    time = PlayerPrefs.GetFloat("Time taken for " + 9);
                    player = i.ToString();
                    break;
                }
                case 10:
                {
                    time = PlayerPrefs.GetFloat("Time taken for " + 10);
                    player = i.ToString();
                    break;
                }
            }
            
            if (time > 0.0f)
            {
                SetScore(player, time);
            }
        }

        if (userScores != null)
        {
            orderedList = userScores.ToList();

            orderedList.Sort(delegate (KeyValuePair<string, float> pair1, KeyValuePair<string, float> pair2) { return pair1.Value.CompareTo(pair2.Value); });
        }
        

        //DEBUG_INITIAL_SETUP();
    }

    void Init()
    {
        if (userScores != null)
        {
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

        //if(userScores.ContainsKey(iD) == false)
        //{
        //    return 0;
        //}

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

    public List<KeyValuePair<string, float>> GetOrder()
    {
        return orderedList;
    }
}
