using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneySystemManager : MonoBehaviour
{
    public static MoneySystemManager instance;

    public float money;

    private static MoneySystemManager _instance
    {
        get
        {
            //if the instance is null, first make sure there's not already a gameobject named MoneySystem. If there is, check for the
            //MoneySystem component and set it as instance, otherwise add the component and set the new one as instance.
            // If there isn't a gameobject named MoneySystem, make one and add the MoneySystem component.
            //Lastly, return the instance.
            if (instance == null)
            {
                if (GameObject.Find("MoneySystem"))
                {
                    GameObject g = GameObject.Find("MoneySystem");
                    if (g.GetComponent<MoneySystemManager>())
                    {
                        instance = g.GetComponent<MoneySystemManager>();
                    }
                    else
                    {
                        instance = g.AddComponent<MoneySystemManager>();
                    }
                }
                else
                {
                    GameObject g = new GameObject();
                    g.name = "MoneySystem";
                    instance = g.AddComponent<MoneySystemManager>();
                }
            }

            return instance;
        }


        set
        {
            instance = value;
        }
    }

    public static bool BuyItem(float cost)
    {
        if (InteractedManager.vehicle.isBought) return false;

        if (_instance.money - cost >= 0)
        {
            InteractedManager.vehicle.isBought = true;

            _instance.money -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetCoinText(TextMeshProUGUI _moneyText)
    {
        _moneyText.text = $"{instance.money}$";
    }
}
