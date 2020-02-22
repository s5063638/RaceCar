using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour {

    public GameObject general;
    public GameObject mustangCar;
    public GameObject demonCar;
    public GameObject chrysterCar;
    public GameObject audoCar;
    public GameObject hotrodCar;
    public GameObject carOptions;
    public GameObject details;
    public GameObject myMoney;

    private StoreCarDetails carDetails;

	// Use this for initialization
	void Awake ()
    {
        AnalyticsEvent.StoreOpened(StoreType.Soft);
    }

    void Start()
    {
        general = GameObject.Find("General");
        demonCar = GameObject.Find("DemonCarPlatform");
        mustangCar = GameObject.Find("MustangCarPlatform");
        chrysterCar = GameObject.Find("ChrysterCarPlatform");
        audoCar = GameObject.Find("AudoCarPlatform");
        hotrodCar = GameObject.Find("HotrodCarPlatform");
        carOptions = GameObject.Find("CarOptions");
        details = GameObject.Find("CarDetails + Upgrades");
        myMoney = GameObject.FindWithTag("Money");

        carDetails = details.GetComponent<StoreCarDetails>();

        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        details.SetActive(false);

        myMoney.GetComponent<TextMeshProUGUI>().text = "My Money: $" + PlayerPrefs.GetInt("Money").ToString();
    }

    public void Buy()
    {
        //Insert stuff about buying here
        string carViewed = PlayerPrefs.GetString("CarViewed");
        string carEquipped = PlayerPrefs.GetString("CarChosen");
        string owned = "";
        int money = PlayerPrefs.GetInt("Money");

        carDetails.UpdateCar();

        if(carViewed == "Mustang")
        {
            owned = PlayerPrefs.GetString("MustangOwned");
            if (owned == "YES")
            {
                if (carEquipped != "Mustang")
                {
                    PlayerPrefs.SetString("CarChosen", "Mustang");
                    carDetails.Equipped();
                }
            }
        }
        if (carViewed == "Demon")
        {
            owned = PlayerPrefs.GetString("DemonOwned");
            if (owned == "YES")
            {
                if (carEquipped != "Demon")
                {
                    PlayerPrefs.SetString("CarChosen", "Demon");
                    carDetails.Equipped();
                }
            }
            else
            {
                if (money >= 10000)
                {
                    money -= 10000;
                    PlayerPrefs.SetInt("Money", money);
                    PlayerPrefs.SetString("DemonOwned", "YES");
                    carDetails.Purchased();
                }
            }
        }
        else if (carViewed == "Chryster")
        {
            owned = PlayerPrefs.GetString("ChrysterOwned");
            if (owned == "YES")
            {
                if (carEquipped != "Chryster")
                {
                    PlayerPrefs.SetString("CarChosen", "Chryster");
                    carDetails.Equipped();
                }
            }
            else
            {
                if (money >= 15450)
                {
                    money -= 15450;
                    PlayerPrefs.SetInt("Money", money);
                    PlayerPrefs.SetString("ChrysterOwned", "YES");
                    carDetails.Purchased();
                }
            }
        }
        else if (carViewed == "Audo")
        {
            owned = PlayerPrefs.GetString("AudoOwned");
            if (owned == "YES")
            {
                if (carEquipped != "Audo")
                {
                    PlayerPrefs.SetString("CarChosen", "Audo");
                    carDetails.Equipped();
                }
            }
            else
            {
                if (money >= 25000)
                {
                    money -= 25000;
                    PlayerPrefs.SetInt("Money", money);
                    PlayerPrefs.SetString("AudoOwned", "YES");
                    carDetails.Purchased();
                }
            }
        }
        else if (carViewed == "Hotrod")
        {
            owned = PlayerPrefs.GetString("HotOwned");
            if (owned == "YES")
            {
                if (carEquipped != "Hotrod")
                {
                    PlayerPrefs.SetString("CarChosen", "Hotrod");
                    carDetails.Equipped();
                }
            }
            else
            {
                if (money >= 25000)
                {
                    money -= 25000;
                    PlayerPrefs.SetInt("Money", money);
                    PlayerPrefs.SetString("HotOwned", "YES");
                    carDetails.Purchased();
                }
            }
        }

        myMoney.GetComponent<TextMeshProUGUI>().text = "My Money: $" + PlayerPrefs.GetInt("Money").ToString();
    }

    public void Back()
    {
        AnalyticsEvent.ScreenVisit(ScreenName.MainMenu);
        PlayerPrefs.SetString("Load", "Main Menu");
        SceneManager.LoadSceneAsync("Load");
    }

    public void DetailsBack()
    {
        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        details.SetActive(false);
        general.SetActive(true);
        carOptions.SetActive(true);
    }

    public void Mustang()
    {
        demonCar.SetActive(false);
        mustangCar.SetActive(true);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarViewed", "Mustang");

        carDetails.UpdateCar();
    }

    public void Demon()
    {
        demonCar.SetActive(true);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarViewed", "Demon");

        carDetails.UpdateCar();
    }

    public void Chryster()
    {
        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(true);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarViewed", "Chryster");

        carDetails.UpdateCar();
    }

    public void Audo()
    {
        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(true);
        hotrodCar.SetActive(false);

        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarViewed", "Audo");
        carDetails.UpdateCar();
    }

    public void HotRod()
    {
        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(true);

        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        PlayerPrefs.SetString("CarViewed", "Hotrod");
        carDetails.UpdateCar();
    }
}