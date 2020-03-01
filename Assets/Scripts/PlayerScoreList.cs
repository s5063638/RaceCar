using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {

    public GameObject playerScoreEntryPrefab;

    Scoreboard scoreboard;

    int lastChangeCounter;

	// Use this for initialization
	void Start ()
    {
        scoreboard = GameObject.FindObjectOfType<Scoreboard>();

        lastChangeCounter = scoreboard.GetChangeCounter();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(scoreboard == null)
        {
            return;
        }

        if(scoreboard.GetChangeCounter() == lastChangeCounter)
        {
            //No change
            return;
        }

        lastChangeCounter = scoreboard.GetChangeCounter();

        while(this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }

        string[] names = scoreboard.GetPlayerNames();

        foreach (string name in names)
        {
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.Find("Header: PlayerID").GetComponent<Text>().text = name;
            go.transform.Find("Header: BestTime").GetComponent<Text>().text = scoreboard.GetScore(name).ToString();
        }
    }
}
