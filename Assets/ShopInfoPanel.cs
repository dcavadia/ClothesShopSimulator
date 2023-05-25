using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopInfoPanel : MonoBehaviour
{
    const string DEFAULT_TEXT = "Need some new clothing or accessories? Or are you looking to update your wardrobe?";
    public TMP_Text infoText;

    public GameObject panelButtons;
    public ShopButton yesButton;
    public ShopButton noButton;

    public void ShowShopItemInfo(Item item)
    {
        infoText.text = "You wanna BUY the item '" + item.name + "' for " + item.price + " coins?";
        yesButton.item = item;

        panelButtons.SetActive(true);
        yesButton.ShopButtonAction += ProcessBuyTransaction;
        noButton.ShopButtonAction += ProcessBuyTransaction;
    }

    public void ShowInventoryItemInfo(Item item)
    {
        infoText.text = "You wanna SELL the item '" + item.name + "' for " + item.price + " coins?";
        yesButton.item = item;

        panelButtons.SetActive(true);
        yesButton.ShopButtonAction += ProcessSellTransaction;
        noButton.ShopButtonAction += ProcessSellTransaction;
    }

    public void ProcessBuyTransaction(Item item)
    {
        yesButton.ShopButtonAction -= ProcessBuyTransaction;
        noButton.ShopButtonAction -= ProcessBuyTransaction;

        if (item != null)
        {
            EconomyManager.Instance.BuyItem(item);
        }
       
        EndTransaction();
    }

    public void ProcessSellTransaction(Item item)
    {
        yesButton.ShopButtonAction -= ProcessSellTransaction;
        noButton.ShopButtonAction -= ProcessSellTransaction;

        if (item != null)
        {
            EconomyManager.Instance.SellItem(item);
        }
        
        EndTransaction();
    }

    public void EndTransaction()
    {
        panelButtons.SetActive(false);
        infoText.text = DEFAULT_TEXT;
    }

}
