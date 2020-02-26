using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crashed : MonoBehaviour {

	public void TryAgain()
    {
        PlayerPrefs.SetString("Load", "Lake Race");
        SceneManager.LoadSceneAsync("Load");
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
