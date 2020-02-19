using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTrigger : MonoBehaviour {

    public GameObject gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM");
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Car")
        {
            gm.GetComponent<GameManager>().Laps();
            this.gameObject.SetActive(false);
        }
    }
}
