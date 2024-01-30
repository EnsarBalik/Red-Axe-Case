using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePriceManager : MonoBehaviour
{
    private VehicleParts vehiclePart;
    private float startPrice = 500;

    public float designatedPrice;

    private void Start()
    {
        vehiclePart = transform.GetComponent<VehicleParts>();

        var damagedPartReducePrice = (vehiclePart.paintedPartCount * 7) + (vehiclePart.damagedPartCount * 7); // 7 is total vehicle parts... I multiply the total damaged and painted parts by 7
        var candidatePrice = startPrice + (vehiclePart.speed) + (vehiclePart.torque) + (vehiclePart.brakeTorque) - damagedPartReducePrice; // 1 speed is 1 dollar and 1 torque is 1 dollar
        designatedPrice = candidatePrice;
    }

}
