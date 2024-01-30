using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerInteractable : MonoBehaviour
{
    [SerializeField] private string interactText;

    public void Interact(Transform interactorTransform)
    {
        transform.LookAt(interactorTransform);
    }

    public string GetInteractText()
    {
        return interactText;
    }
}
