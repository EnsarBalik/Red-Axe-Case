using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleParts : MonoBehaviour
{
    public VehicleSO vehicleSO;

    public List<bool> damagedParts;
    public List<bool> paintedParts;
    public bool isBought;

    public float speed;
    public float torque;
    public float brakeTorque;

    public int damagedPartCount;
    public int paintedPartCount;

    private void Awake()
    {
        VehiclePartList();
        VehicleRandomValue();
    }

    public void VehiclePartList()
    {
        damagedParts.Add(vehicleSO.outerHood_DamagedPercent);
        damagedParts.Add(vehicleSO.roof_DamagedPercent);
        damagedParts.Add(vehicleSO.fender_DamagedPercent);
        damagedParts.Add(vehicleSO.rightDoor_DamagedPercent);
        damagedParts.Add(vehicleSO.leftDoor_DamagedPercent);
        damagedParts.Add(vehicleSO.bodySide_DamagedPercent);
        damagedParts.Add(vehicleSO.trunkLid_DamagedPercent);

        paintedParts.Add(vehicleSO.outerHood_PaintPercent);
        paintedParts.Add(vehicleSO.roof_PaintPercent);
        paintedParts.Add(vehicleSO.fender_PaintPercent);
        paintedParts.Add(vehicleSO.rightDoor_PaintPercent);
        paintedParts.Add(vehicleSO.leftDoor_PaintPercent);
        paintedParts.Add(vehicleSO.bodySide_PaintPercent);
        paintedParts.Add(vehicleSO.trunkLid_PaintPercent);
    }

    public void VehicleRandomValue()
    {
        for (int i = 0; i < damagedParts.Count; i++)
        {
            damagedParts[i] = Random.value >= 0.5f ? true : false;
            paintedParts[i] = Random.value >= 0.5f ? true : false;
            if(damagedParts[i] == true)
            {
                damagedPartCount++;
            }
            if (paintedParts[i] == true)
            {
                paintedPartCount++;
            }
        }

        vehicleSO.speed = Random.Range(100, 500);
        vehicleSO.torque = Random.Range(250, 1000);
        vehicleSO.brakeTorque = Random.Range(1000, 3000);

        speed = vehicleSO.speed;
        torque = vehicleSO.torque;
        brakeTorque = vehicleSO.brakeTorque;
    }

}
