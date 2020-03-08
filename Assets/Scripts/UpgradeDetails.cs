using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeDetails : MonoBehaviour {

    public bool upgradeActive = false;
    int currentUpgrade;
    string currentCar;
    public GameObject buyButton;

    void Start()
    {
        buyButton = GameObject.Find("BUYUpgrade");
    }

    void Update()
    {
        if (upgradeActive)
        {
            GameObject.Find("CurrentMoney").GetComponent<TextMeshProUGUI>().text = "My Money: $" + PlayerPrefs.GetInt("Money").ToString();
            currentCar = PlayerPrefs.GetString("CarViewed");
            currentUpgrade = PlayerPrefs.GetInt("UpgradeViewed");

            switch (currentUpgrade)
            {
                case 1:
                {
                    switch(currentCar)
                    {
                        case "Mustang":
                        {
                            if(PlayerPrefs.GetString("MustangU1") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Demon":
                        {
                            if(PlayerPrefs.GetString("DemonU1") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Chryster":
                        {
                            if(PlayerPrefs.GetString("ChrysterU1") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Audo":
                        {
                            if(PlayerPrefs.GetString("AudoU1") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Hotrod":
                        {
                            if(PlayerPrefs.GetString("HotU1") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                    }
                    break;
                }
                case 2:
                {
                    switch(currentCar)
                    {
                        case "Mustang":
                        {
                            if(PlayerPrefs.GetString("MustangU2") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Demon":
                        {
                            if(PlayerPrefs.GetString("DemonU2") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Chryster":
                        {
                            if(PlayerPrefs.GetString("ChrysterU2") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Audo":
                        {
                            if(PlayerPrefs.GetString("AudoU2") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Hotrod":
                        {
                            if(PlayerPrefs.GetString("HotU2") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                    }
                    break;
                }
                case 3:
                {
                    switch(currentCar)
                    {
                        case "Mustang":
                        {
                            if(PlayerPrefs.GetString("MustangU3") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Demon":
                        {
                            if(PlayerPrefs.GetString("DemonU3") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Chryster":
                        {
                            if(PlayerPrefs.GetString("ChrysterU3") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Audo":
                        {
                            if(PlayerPrefs.GetString("AudoU3") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                        case "Hotrod":
                        {
                            if(PlayerPrefs.GetString("HotU3") == "YES")
                            {
                                buyButton.GetComponent<Button>().interactable = false;
                                buyButton.GetComponentInChildren<Text>().text = "BOUGHT";
                            }
                            else
                            {
                                buyButton.GetComponent<Button>().interactable = true;
                                buyButton.GetComponentInChildren<Text>().text = "BUY";
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
