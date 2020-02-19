using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerprefs : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.DeleteAll();
	}
	
}
