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
    public GameObject upgradeMenu;
    public GameObject cantUpgrade;

    private StoreCarDetails carDetails;
    private UpgradeDetails upgradeDets;
    private int playerID;

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
        upgradeMenu = GameObject.Find("UpgradesCanvas");
        cantUpgrade = GameObject.Find("CantUpgrade");

        carDetails = details.GetComponent<StoreCarDetails>();
        upgradeDets = upgradeMenu.GetComponent<UpgradeDetails>();

        demonCar.SetActive(false);
        mustangCar.SetActive(false);
        chrysterCar.SetActive(false);
        audoCar.SetActive(false);
        hotrodCar.SetActive(false);

        cantUpgrade.SetActive(false);
        details.SetActive(false);
        upgradeMenu.SetActive(false);

        playerID = PlayerPrefs.GetInt("Player ID");

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

                    AnalyticsEvent.Custom("demon_bought", new Dictionary<string, object>
                    {
                        { "PlayerID", playerID}
                    });
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
                    AnalyticsEvent.Custom("chryster_bought", new Dictionary<string, object>
                    {
                        { "PlayerID", playerID}
                    });
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
                    AnalyticsEvent.Custom("audo_bought", new Dictionary<string, object>
                    {
                        { "PlayerID", playerID}
                    });
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
                    AnalyticsEvent.Custom("hotrod_bought", new Dictionary<string, object>
                    {
                        { "PlayerID", playerID}
                    });
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

        cantUpgrade.SetActive(false);
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
        AnalyticsEvent.Custom("mustang_viewed", new Dictionary<string, object>
        {
            { "PlayerID", playerID}
        });

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
        AnalyticsEvent.Custom("demon_viewed", new Dictionary<string, object>
        {
            { "PlayerID", playerID}
        });

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
        AnalyticsEvent.Custom("chryster_viewed", new Dictionary<string, object>
        {
            { "PlayerID", playerID}
        });

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
        AnalyticsEvent.Custom("audo_viewed", new Dictionary<string, object>
        {
            { "PlayerID", playerID}
        });

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
        AnalyticsEvent.Custom("hotrod_viewed", new Dictionary<string, object>
        {
            { "PlayerID", playerID}
        });

        carDetails.UpdateCar();
    }

    public void UpgradeMenu(int upgrade)
    {
        if (GameObject.Find("Cost").GetComponent<TextMeshProUGUI>().text == "Already Owned")
        {
            upgradeMenu.SetActive(true);
            cantUpgrade.SetActive(false);
            details.SetActive(false);
            general.SetActive(false);
            carOptions.SetActive(false);

            upgradeDets.upgradeActive = true;

            PlayerPrefs.SetInt("UpgradeViewed", upgrade);
            string carName = PlayerPrefs.GetString("CarViewed");

            switch (upgrade)
            {
                case 1:
                    {
                        GameObject.Find("Upgrade name").GetComponent<TextMeshProUGUI>().text = "Bigger Engine";
                        GameObject.Find("UpgradeText").GetComponent<TextMeshProUGUI>().text = "Permanently increases the maximum speed of the car";
                        switch (carName)
                        {
                            case "Mustang":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $2500";
                                    break;
                                }
                            case "Demon":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $3000";
                                    break;
                                }
                            case "Chryster":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $4000";
                                    break;
                                }
                            case "Audo":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $5000";
                                    break;
                                }
                            case "Hotrod":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $4500";
                                    break;
                                }
                        }
                        break;
                    }
                case 2:
                    {
                        GameObject.Find("Upgrade name").GetComponent<TextMeshProUGUI>().text = "Turbo Boost";
                        GameObject.Find("UpgradeText").GetComponent<TextMeshProUGUI>().text = "Gives the car a short boost at the start of the next race";

                        switch (carName)
                        {
                            case "Mustang":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $500";
                                    break;
                                }
                            case "Demon":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $750";
                                    break;
                                }
                            case "Chryster":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $900";
                                    break;
                                }
                            case "Audo":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $1000";
                                    break;
                                }
                            case "Hotrod":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $1000";
                                    break;
                                }
                        }
                        break;
                    }
                case 3:
                    {
                        GameObject.Find("Upgrade name").GetComponent<TextMeshProUGUI>().text = "Better Tires";
                        GameObject.Find("UpgradeText").GetComponent<TextMeshProUGUI>().text = "Permanently improves the handling of the car";

                        switch (carName)
                        {
                            case "Mustang":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $2000";
                                    break;
                                }
                            case "Demon":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $2500";
                                    break;
                                }
                            case "Chryster":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $3500";
                                    break;
                                }
                            case "Audo":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $4500";
                                    break;
                                }
                            case "Hotrod":
                                {
                                    GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>().text = "Cost: $4000";
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        else
        {
            StartCoroutine(CantUpgradeYet());
        }
    }

    public void UpgradeBuy()
    {
        string car = PlayerPrefs.GetString("CarViewed");
        int upgrade = PlayerPrefs.GetInt("UpgradeViewed");
        int money = PlayerPrefs.GetInt("Money");
        GameObject button = GameObject.Find("BUYUpgrade");

        switch(upgrade)
        {
            case 1:
            {
                switch(car)
                {
                    case "Mustang":
                    {
                        if(PlayerPrefs.GetString("MustangU1") != "YES")
                        {
                            if(money >= 2500)
                            {
                                money -= 2500;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("MustangU1", "YES");
                            }
                        }
                        break;
                    }
                    case "Demon":
                    {
                        if(PlayerPrefs.GetString("DemonU1") != "YES")
                        {
                            if(money >= 3000)
                            {
                                money -= 3000;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("DemonU1", "YES");
                            }
                        }
                        break;
                    }
                    case "Chryster":
                    {
                        if(PlayerPrefs.GetString("ChrysterU1") != "YES")
                        {
                            if(money >= 4000)
                            {
                                money -= 4000;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("ChrysterU1", "YES");
                            }
                        }
                        break;
                    }
                    case "Audo":
                    {
                        if(PlayerPrefs.GetString("AudoU1") != "YES")
                        {
                            if(money >= 5000)
                            {
                                money -= 5000;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("AudoU1", "YES");
                            }
                        }
                        break;
                    }
                    case "Hotrod":
                    {
                        if(PlayerPrefs.GetString("HotU1") != "YES")
                        {
                            if(money >= 4500)
                            {
                                money -= 4500;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("HotU1", "YES");
                            }
                        }
                        break;
                    }
                }
                break;
            }
            case 2:
            {
                switch(car)
                {
                    case "Mustang":
                    {
                        if(PlayerPrefs.GetString("MustangU2") != "YES")
                        {
                            if(money >= 500)
                            {
                                money -= 500;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("MustangU2", "YES");
                            }
                        }
                        break;
                    }
                    case "Demon":
                    {
                        if(PlayerPrefs.GetString("DemonU2") != "YES")
                        {
                            if(money >= 750)
                            {
                                money -= 750;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("DemonU2", "YES");
                            }
                        }
                        break;
                    }
                    case "Chryster":
                    {
                        if(PlayerPrefs.GetString("ChrysterU2") != "YES")
                        {
                            if(money >= 900)
                            {
                                money -= 900;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("ChrysterU2", "YES");
                            }
                        }
                        break;
                    }
                    case "Audo":
                    {
                        if(PlayerPrefs.GetString("AudoU2") != "YES")
                        {
                            if(money >= 1000)
                            {
                                money -= 1000;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("AudoU2", "YES");
                            }
                        }
                        break;
                    }
                    case "Hotrod":
                    {
                        if(PlayerPrefs.GetString("HotU2") != "YES")
                        {
                            if(money >= 1000)
                            {
                                money -= 1000;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("HotU2", "YES");
                            }
                        }
                        break;
                    }
                }
                break;
            }
            case 3:
            {
                switch(car)
                {
                    case "Mustang":
                    {
                        if(PlayerPrefs.GetString("MustangU3") != "YES")
                        {
                            if(money >= 2000)
                            {
                                money -= 2000;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("MustangU3", "YES");
                            }
                        }
                        break;
                    }
                    case "Demon":
                    {
                        if(PlayerPrefs.GetString("DemonU3") != "YES")
                        {
                            if(money >= 2500)
                            {
                                money -= 2500;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("DemonU3", "YES");
                            }
                        }
                        break;
                    }
                    case "Chryster":
                    {
                        if(PlayerPrefs.GetString("ChrysterU3") != "YES")
                        {
                            if(money >= 3500)
                            {
                                money -= 3500;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("ChrysterU3", "YES");
                            }
                        }
                        break;
                    }
                    case "Audo":
                    {
                        if(PlayerPrefs.GetString("AudoU3") != "YES")
                        {
                            if(money >= 4500)
                            {
                                money -= 4500;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("AudoU3", "YES");
                            }
                        }
                        break;
                    }
                    case "Hotrod":
                    {
                        if(PlayerPrefs.GetString("HotU3") != "YES")
                        {
                            if(money >= 4000)
                            {
                                money -= 4000;
                                PlayerPrefs.SetInt("Money", money);
                                PlayerPrefs.SetString("HotU3", "YES");
                            }
                        }
                        break;
                    }
                }
                break;
            }
        }
    }

    public void UpgradeBack()
    {
        upgradeDets.upgradeActive = false;

        upgradeMenu.SetActive(false);
        details.SetActive(true);
        general.SetActive(false);
        carOptions.SetActive(false);

        myMoney.GetComponent<TextMeshProUGUI>().text = "My Money: $" + PlayerPrefs.GetInt("Money").ToString();
    }

    IEnumerator CantUpgradeYet()
    {
        cantUpgrade.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        cantUpgrade.SetActive(false);
    }
}