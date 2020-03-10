using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboLimiter : MonoBehaviour {


	public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Car" && PlayerPrefs.GetString(PlayerPrefs.GetString("CarChosen") + "U2") == "YES")
        {
            collider.GetComponent<CarScript>().accelerateLimit -= 63;
            PlayerPrefs.SetString(PlayerPrefs.GetString("CarChosen") + "U2", "NO");
        }
    }
}
