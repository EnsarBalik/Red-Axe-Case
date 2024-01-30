using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    PlayerController playerController;

    private VehicleParts vehiclePart;
    private VehiclePriceManager vehiclePrice;
    [SerializeField] public RCC_CarControllerV3 vehicle;

    public float maxDistance = 2f;   //Raycast Max interactable distance
    public LayerMask layer;   //layer for raycast

    RaycastHit hit;   //ray hit

    private bool isHit;   //Is raycast hit vehicle or costumer 
    private bool isInteracted;   //is pressed E?

    Collider[] colliderArray;   //We're having the colliders calculated

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        colliderArray = Physics.OverlapSphere(transform.position, maxDistance, layer);
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Collider col in colliderArray)
            {
                if (col.TryGetComponent(out SellerInteractable costumer))
                {
                    InteractedManager.InteractPrice();
                    UIManager.instance.VehicleFeaturesNaming();
                    costumer.Interact(transform);
                    isInteracted = true;
                }
            }
        }

        InteractedCar();

        if (Input.GetKeyDown(KeyCode.Escape) && isInteracted) //player press esc UI will close(interaction will end)
            DisableInteraction();

        if (vehicle != null && vehicle.isBought) //Player bought the car interaction will end
            isInteracted = false;
        else
            return;
    }

    public SellerInteractable GetInteractableObject()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, maxDistance);
        foreach (Collider col in colliderArray)
        {
            vehiclePart = col.GetComponent<VehicleParts>();
            vehiclePrice = col.GetComponent<VehiclePriceManager>();
            InteractedManager.InteractPart(vehiclePart, vehiclePrice);

            if (col.TryGetComponent(out SellerInteractable costumer))
            {
                return costumer;
            }
        }
        return null;
    }

    public bool Interacted()
    {
        if (isInteracted)
        {
            playerController.enabled = false;
            return true;
        }
        else
        {
            playerController.enabled = true;
            return false;
        }
    }

    private void InteractedCar()
    {
        foreach (Collider col in colliderArray)
        {
            if (col.TryGetComponent(out RCC_CarControllerV3 vehicle))
            {
                this.vehicle = col ? vehicle : null;

                InteractedManager.InteractCar(vehicle);
            }

        }
    }

    private void OnDrawGizmos() //this method is only for the developer convenience
    {
        isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 15, transform.forward, out hit, maxDistance, layer);

        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, transform.lossyScale.x / 15);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }

    public void DisableInteraction()
    {
        isInteracted = false;
    }
}
