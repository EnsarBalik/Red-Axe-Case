using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;
    [SerializeField] private PlayerInteract playerInteract;

    [SerializeField] private GameObject interactableContainerGameObject; //containeri of seller name
    [SerializeField] private GameObject VehichleContainerGameObject;  //vehicle features (damaged places, painted places, speed and torque)
    [SerializeField] private GameObject dealMenuUI;

    [SerializeField] private TextMeshProUGUI interactTextName;   // shows who we are talking to( seller name )

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)   // if it's interacted, the "Press E" screen comes up.
            Show(playerInteract.GetInteractableObject());
        else
            Hide();

        if (!playerInteract.gameObject.activeInHierarchy)   // when we get in the car we deactivate the character so we don't want the press E UI on the screen
            Hide();

        if (playerInteract.Interacted())
        {
            ShowVehicleAd();
            playerInteract.Interacted();
            Hide(); // Hide Interactable UI (Press E UI is hidden)
        }
        else
        {
            HideVehicleAd();
            HideDealMenu();
            playerInteract.Interacted();
        }
    }

    private void Show(SellerInteractable costumerInteractable)
    {
        interactableContainerGameObject.SetActive(true);
        interactTextName.text = costumerInteractable.GetInteractText();
    }

    private void Hide()
    {
        interactableContainerGameObject.SetActive(false);
    }

    private void ShowVehicleAd()
    {
        UIManager.PriceController();
        VehichleContainerGameObject.SetActive(true);
    }

    public void HideVehicleAd()
    {
        VehichleContainerGameObject.SetActive(false);
    }

    public void ShowDealMenu()
    {
        dealMenuUI.SetActive(true);
    }

    private void HideDealMenu()
    {
        dealMenuUI.SetActive(false);
    }

    public void BuyItem()
    {
        MoneySystemManager.BuyItem(InteractedManager.interactedPrice);
        playerInteract.DisableInteraction();
    }

}
