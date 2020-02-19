using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRace : MonoBehaviour {

	void Awake()
    {
        string level = PlayerPrefs.GetString("Load");
        SceneManager.LoadSceneAsync(level);
    }
}
