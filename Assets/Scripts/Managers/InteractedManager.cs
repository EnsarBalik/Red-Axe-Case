using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractedManager : MonoBehaviour
{
    public static InteractedManager instance;

    public static VehicleParts vehiclePart;
    public static VehiclePriceManager vehiclePrice;
    public static RCC_CarControllerV3 vehicle;

    public static float interactedPrice;

    private static InteractedManager _instance
    {
        get
        {
            //Same logic with MoneySystemManager
            if (instance == null)
            {
                if (GameObject.Find("Canvas"))
                {
                    GameObject g = GameObject.Find("Canvas");
                    if (g.GetComponent<InteractedManager>())
                    {
                        instance = g.GetComponent<InteractedManager>();
                    }
                    else
                    {
                        instance = g.AddComponent<InteractedManager>();
                    }
                }
                else
                {
                    GameObject g = new GameObject();
                    g.name = "Interacted Manager";
                    instance = g.AddComponent<InteractedManager>();
                }
            }

            return instance;
        }


        set
        {
            instance = value;
        }
    }

    public static void InteractPrice()
    {
        interactedPrice = vehiclePrice.designatedPrice;
    }

    public static void InteractPart(VehicleParts _vehicleParts, VehiclePriceManager _vehiclePrice)
    {
        vehiclePart = _vehicleParts;
        vehiclePrice = _vehiclePrice;
    }

    public static void InteractCar(RCC_CarControllerV3 _vehicle)
    {
        vehicle = _vehicle;
    }
}
