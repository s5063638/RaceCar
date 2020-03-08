using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {

    public GameObject playerScoreEntryPrefab;

    Scoreboard scoreboard;

    int lastChangeCounter;

    List<KeyValuePair<string, float>> values;

    // Use this for initialization
    void Start ()
    {
        scoreboard = GameObject.FindObjectOfType<Scoreboard>();

        lastChangeCounter = scoreboard.GetChangeCounter();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(values == null)
        {
            if(scoreboard.GetOrder() == null)
            {
                return;
            }
            values = scoreboard.GetOrder();
        }
		if(scoreboard == null)
        {
            return;
        }

        //if(scoreboard.GetChangeCounter() == lastChangeCounter)
        //{
        //    Debug.Log("UPDATING");
        //    //No change
        //    return;
        //}

        lastChangeCounter = scoreboard.GetChangeCounter();

        while(this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }

        string[] names = scoreboard.GetPlayerNames();

        //Debug.Log(values[0].Value);

        string mins = "";
        string secs = "";
        string fullTime = "";

        for(int i = 0; i < values.Count; i++)
        {
            mins = Mathf.Floor(values[i].Value / 60).ToString("00");
            secs = Mathf.Floor(values[i].Value % 60).ToString("00");
            fullTime = mins + ":" + secs;

            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.Find("Header: PlayerID").GetComponent<Text>().text = values[i].Key;
            go.transform.Find("Header: BestTime").GetComponent<Text>().text = fullTime;
        }

        //foreach (string name in names)
        //{
        //    GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
        //    go.transform.SetParent(this.transform);
        //    go.transform.Find("Header: PlayerID").GetComponent<Text>().text = name;
        //    go.transform.Find("Header: BestTime").GetComponent<Text>().text = scoreboard.GetScore(name).ToString();
        //}
    }
}
