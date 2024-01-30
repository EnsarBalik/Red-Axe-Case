using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Acýklama: pazarlýk sistemini bize býrakmýþsýnýz benimde aklýma pek bir þey gelmedi o yüzden...
//Bu þekilde yaptým verdiði teklifin yüzdesini hesaplýyorum eðer yüzde 75 den yüksek bir sayý söylediyse satýn alabiliyor
//Farklý yöntem olarak belki þu yapýlabilirdi: oyuncu sayý söylediði zaman belli oranýn altýndaysa costumer üstüne ekleyerek bir teklif sunabilirdi.


public class PriceNegotiation : MonoBehaviour
{
    [SerializeField] private PlayerInteract playerInteract;

    public TMP_InputField CandidatePrice;
    public TextMeshProUGUI playerDesiredPriceText;
    public TextMeshProUGUI costumerDesiredPriceText;
    public TextMeshProUGUI finalPriceOfferText;

    public float playerDesiredPrice;
    public float costumerDesiredPrice;
    public float finalPriceOffer;

    private float mainPrice;

    public void PlayerOffer()
    {
        mainPrice = InteractedManager.interactedPrice;

        playerDesiredPrice = int.Parse(CandidatePrice.text);
        playerDesiredPriceText.text = $"{playerDesiredPrice}$";
        CostumerOffer();
    }

    private void CostumerOffer()
    {
        var percentage = playerDesiredPrice / mainPrice * 100;

        if (percentage > 75)
        {
            Debug.Log("You Can Deal");
            finalPriceOffer = playerDesiredPrice;
            finalPriceOfferText.text = $"{finalPriceOffer}$";
            costumerDesiredPriceText.text = $"{playerDesiredPrice}$";
        }
        else if (percentage <= 75)
        {
            RandomRangeExcept(mainPrice - playerDesiredPrice, mainPrice, playerDesiredPrice);
            costumerDesiredPriceText.text = $"{costumerDesiredPrice}$";
            finalPriceOffer = costumerDesiredPrice;
            finalPriceOfferText.text = $"{finalPriceOffer}$";
        }
    }

    private float RandomRangeExcept(float min, float max, float except)
    {
        costumerDesiredPrice = Random.Range(min, max);
        if (costumerDesiredPrice <= except)
        {
            costumerDesiredPrice += except;
        }
        if (costumerDesiredPrice >= max)
        {
            costumerDesiredPrice = max + Random.Range(100, 200);
        }
        return costumerDesiredPrice;
    }

    public void BuyCar()
    {
        Debug.Log("Car is Yours");
        MoneySystemManager.BuyItem(finalPriceOffer);
        playerInteract.DisableInteraction();
    }
}
