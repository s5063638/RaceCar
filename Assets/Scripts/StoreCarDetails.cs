using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreCarDetails : MonoBehaviour {

    TextMeshProUGUI carName;
    TextMeshProUGUI speed;
    TextMeshProUGUI zeroSixty;
    TextMeshProUGUI handling;
    TextMeshProUGUI cost;
    GameObject buyButton;

    string car;

    string mustangOwned;
    string demonOwned;
    string chrysterOwned;
    string audoOwned;
    string hotOwned;
    string carEquipped;

	// Use this for initialization
	void Start ()
    {
        carName = GameObject.FindGameObjectWithTag("CarName").GetComponent<TextMeshProUGUI>();
        speed = GameObject.FindGameObjectWithTag("Speed").GetComponent<TextMeshProUGUI>();
        zeroSixty = GameObject.FindGameObjectWithTag("ZeroSixty").GetComponent<TextMeshProUGUI>();
        handling = GameObject.FindGameObjectWithTag("Handling").GetComponent<TextMeshProUGUI>();
        cost = GameObject.FindGameObjectWithTag("Cost").GetComponent<TextMeshProUGUI>();
        buyButton = GameObject.FindGameObjectWithTag("BuyButton");

        mustangOwned = PlayerPrefs.GetString("MustangOwned");
        demonOwned = PlayerPrefs.GetString("DemonOwned");
        chrysterOwned = PlayerPrefs.GetString("ChrysterOwned");
        audoOwned = PlayerPrefs.GetString("AudoOwned");
        hotOwned = PlayerPrefs.GetString("HotOwned");

        carEquipped = PlayerPrefs.GetString("CarChosen");
	}

    public void UpdateCar()
    {
        car = PlayerPrefs.GetString("CarViewed");

        if(car == "Mustang")
        {
            carName.text = "Mustang";
            speed.text = "Speed: 80mph";
            zeroSixty.text = "0-60: 2 Seconds";
            handling.text = "Handling: Medium";

            if (mustangOwned == "YES")
            {
                cost.text = "Already Owned";

                if (carEquipped == car)
                {
                    buyButton.GetComponent<Button>().interactable = false;
                    buyButton.GetComponentInChildren<Text>().text = "Chosen for race";
                    buyButton.GetComponentInChildren<Text>().fontSize = 23;
                }
                else
                {
                    buyButton.GetComponent<Button>().interactable = true;
                    buyButton.GetComponentInChildren<Text>().text = "Use for Race?";
                    buyButton.GetComponentInChildren<Text>().fontSize = 23;
                }
            }
            else
            {
                buyButton.GetComponent<Button>().interactable = true;
                buyButton.GetComponentInChildren<Text>().text = "Buy";
                buyButton.GetComponentInChildren<Text>().fontSize = 35;
            }
        }
        else if (car == "Demon")
        {
            carName.text = "Demon";
            speed.text = "Speed: 95mph";
            zeroSixty.text = "0-60: 1.5 Seconds";
            handling.text = "Handling: Low Medium";

            if (demonOwned == "YES")
            {
                cost.text = "Already Owned";

                if (carEquipped == car)
                {
                    buyButton.GetComponent<Button>().interactable = false;
                    buyButton.GetComponentInChildren<Text>().text = "Chosen for race";
                    buyButton.GetComponentInChildren<Text>().fontSize = 23;
                }
                else
                {
                    buyButton.GetComponent<Button>().interactable = true;
                    buyButton.GetComponentInChildren<Text>().text = "Use for Race?";
                    buyButton.GetComponentInChildren<Text>().fontSize = 23;
                }
            }
            else
            {
                cost.text = "Cost: $10,000";

                buyButton.GetComponent<Button>().interactable = true;
                buyButton.GetComponentInChildren<Text>().text = "Buy";
                buyButton.GetComponentInChildren<Text>().fontSize = 35;
            }
        }
        else if (car == "Chryster")
        {
            carName.text = "Chryster";
            speed.text = "Speed: 85mph";
            zeroSixty.text = "0-60: 1.95 Seconds";
            handling.text = "Handling: High Medium";

            if (chrysterOwned == "YES")
            {
                cost.text = "Already Owned";

                if (carEquipped == car)
                {
                    buyButton.GetComponent<Button>().interactable = false;
                    buyButton.GetComponentInChildren<Text>().text = "Chosen for race";
                    buyButton.GetComponentInChildren<Text>().fontSize = 23;
                }
                else
                {
                    buyButton.GetComponent<Button>().interactable = true;
                    buyButton.GetComponentInChildren<Text>().text = "Use for Race?";
                    buyButton.GetComponentInChildren<Text>().fontSize = 23;
                }
            }
            else
            {
                cost.text = "Cost: $15,450";

                buyButton.GetComponent<Button>().interactable = true;
                buyButton.GetComponentInChildren<Text>().text = "Buy";
                buyButton.GetComponentInChildren<Text>().fontSize = 35;
            }
        }
        else if (car == "Audo")
        {
            carName.text = "Audo";
            speed.text = "Speed: 110mph";
            zeroSixty.text = "0-60: 1.25 Seconds";
            handling.text = "Handling: High";

            if (audoOwned == "YES")
            {
                cost.text = "Already Owned";

                if (carEquipped == car)
                {
                    buyButton.GetComponent<Button>().interactable = false;
                    buyButton.GetComponentInChildren<Text>().text = "Chosen for race";
                    buyButton.GetComponentInChildren<Text>().fontSize = 23;
                }
                else
                {
                    buyButton.GetComponent<Button>().interactable = true;
                    buyButton.GetComponentInChildren<Text>().text = "Use for Race?";
                    buyButton.GetComponentInChildren<Text>().fontSize = 23;
                }
            }
            else
            {
                cost.text = "Cost: $25,000";

                buyButton.GetComponent<Button>().interactable = true;
                buyButton.GetComponentInChildren<Text>().text = "Buy";
                buyButton.GetComponentInChildren<Text>().fontSize = 35;
            }
        }
        else if (car == "Hotrod")
        {
            carName.text = "Hot Rod";
            speed.text = "Speed: 100mph";
            zeroSixty.text = "0-60: 1.75 Seconds";
            handling.text = "Handling: Very High";

            if (hotOwned == "YES")
            {
                cost.text = "Already Owned";

                if (carEquipped == car)
                {
                    buyButton.GetComponent<Button>().interactable = false;
                    buyButton.GetComponentInChildren<Text>().text = "Chosen for race";
                    buyButton.GetComponentInChildren<Text>().fontSize = 23;
                }
                else
                {
                    buyButton.GetComponent<Button>().interactable = true;
                    buyButton.GetComponentInChildren<Text>().text = "Use for Race?";
                    buyButton.GetComponentInChildren<Text>().fontSize = 23;
                }
            }
            else
            {
                cost.text = "Cost: $25,000";

                buyButton.GetComponent<Button>().interactable = true;
                buyButton.GetComponentInChildren<Text>().text = "Buy";
                buyButton.GetComponentInChildren<Text>().fontSize = 35;
            }
        }
    }
}
