using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreTrigger : MonoBehaviour {

    public GameObject lap;

    private void Awake()
    {
        lap = GameObject.FindGameObjectWithTag("Finish");
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Car")
        {
            lap.SetActive(true);
        }
    }
}
