using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerprefs : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("MustangOwned", "YES");
        PlayerPrefs.SetString("CarChosen", "Mustang");
        PlayerPrefs.SetInt("Money", 0);
	}
	
}
