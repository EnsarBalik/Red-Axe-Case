using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI priceText;

    [Header("DAMAGED PART")]
    public TextMeshProUGUI outerHood_Percent;
    public TextMeshProUGUI roof_Percent;
    public TextMeshProUGUI fender_Percent;
    public TextMeshProUGUI rightDoor_Percent;
    public TextMeshProUGUI leftDoor_Percent;
    public TextMeshProUGUI bodySide_Percent;
    public TextMeshProUGUI trunkLid_Percent;

    [Header("PAINTED PART")]
    public TextMeshProUGUI outerHoodPainted_Percent;
    public TextMeshProUGUI roofPainted_Percent;
    public TextMeshProUGUI fenderPainted_Percent;
    public TextMeshProUGUI rightDoorPainted_Percent;
    public TextMeshProUGUI leftDoorPainted_Percent;
    public TextMeshProUGUI bodySidePainted_Percent;
    public TextMeshProUGUI trunkLidPainted_Percent;

    [Header("Speed&Torque&BrakeTorque")]
    public TextMeshProUGUI speed;
    public TextMeshProUGUI torque;
    public TextMeshProUGUI brakeTorque;

    private void Start()
    {
        instance = this;
    }

    public void VehicleFeaturesNaming()
    {
        var vehiclePart = InteractedManager.vehiclePart;

        outerHood_Percent.text = $"Hood Damaged = {vehiclePart.damagedParts[0]}";
        roof_Percent.text = $"Roof Damaged = {vehiclePart.damagedParts[1]}";
        fender_Percent.text = $"Fender Damaged = {vehiclePart.damagedParts[2]}";
        rightDoor_Percent.text = $"Roof Damaged = {vehiclePart.damagedParts[3]}";
        leftDoor_Percent.text = $"Left Door Damaged = {vehiclePart.damagedParts[4]}";
        bodySide_Percent.text = $"Side Body Damaged = {vehiclePart.damagedParts[5]}";
        trunkLid_Percent.text = $"Trunk Lid Damaged = {vehiclePart.damagedParts[6]}";

        outerHoodPainted_Percent.text = $"Hood Painted = {vehiclePart.paintedParts[0]}";
        roofPainted_Percent.text = $"Roof Painted = {vehiclePart.paintedParts[1]}";
        fenderPainted_Percent.text = $"Fender Painted = {vehiclePart.paintedParts[2]}";
        rightDoorPainted_Percent.text = $"Roof Painted = {vehiclePart.paintedParts[3]}";
        leftDoorPainted_Percent.text = $"Left Door Painted = {vehiclePart.paintedParts[4]}";
        bodySidePainted_Percent.text = $"Side Body Painted = {vehiclePart.paintedParts[5]}";
        trunkLidPainted_Percent.text = $"Trunk Lid Painted = {vehiclePart.paintedParts[6]}";

        speed.text = $"Speed = {vehiclePart.speed}";
        torque.text = $"Torque = {vehiclePart.torque}";
        brakeTorque.text = $"Brake Torque = {vehiclePart.brakeTorque}";
    }

    public void PriceController()
    {
        priceText.text = $"{InteractedManager.interactedPrice} $";
    }
}
