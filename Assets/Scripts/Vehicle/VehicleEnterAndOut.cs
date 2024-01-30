using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleEnterAndOut : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private GameObject rccCam;

    [Header("Player & entered car controller")]
    [SerializeField] private PlayerInteract player;
    private bool isInCar = false;

    [SerializeField] KeyCode enterExitKey = KeyCode.F; //Keycode

    private void Update()
    {
        if (player.vehicle == null) return;
        if (Input.GetKeyDown(enterExitKey))
        {
            if (!InteractedManager.vehicle.isBought) return;

            if (isInCar)
                GetOutOfCar();
            else
                GetIntoCar();
        }
    }

    private void GetOutOfCar()
    {
        isInCar = false;
        player.gameObject.SetActive(true);
        player.transform.position = InteractedManager.vehicle.transform.position + InteractedManager.vehicle.transform.TransformDirection(Vector3.left);
        InteractedManager.vehicle.enabled = false;
        rccCam.gameObject.SetActive(false);
    }

    private void GetIntoCar()
    {
        isInCar = true;
        player.gameObject.SetActive(false);
        InteractedManager.vehicle.enabled = true;
        rccCam.gameObject.SetActive(true);
    }
}
