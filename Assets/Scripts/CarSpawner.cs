using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {


    // Use this for initialization
	void Start ()
    {
        string car = PlayerPrefs.GetString("CarChosen");

        Instantiate(Resources.Load(car));
	}
}
