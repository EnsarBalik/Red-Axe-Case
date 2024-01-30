using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VehicleData", menuName = "Vehicle/vehicleDATA")]
public class VehicleSO : ScriptableObject
{
    [Header("Damaged Parts")]
    public bool outerHood_DamagedPercent;
    public bool roof_DamagedPercent;
    public bool fender_DamagedPercent;
    public bool rightDoor_DamagedPercent;
    public bool leftDoor_DamagedPercent;
    public bool bodySide_DamagedPercent;
    public bool trunkLid_DamagedPercent;

    [Header("Painted Parts")]
    public bool outerHood_PaintPercent;
    public bool roof_PaintPercent;
    public bool fender_PaintPercent;
    public bool rightDoor_PaintPercent;
    public bool leftDoor_PaintPercent;
    public bool bodySide_PaintPercent;
    public bool trunkLid_PaintPercent;

    [Header("Speed, Torque")]
    public float speed;
    public float torque;
    public float brakeTorque;

    [Header("is Purchased")]
    public bool isBought;
}
