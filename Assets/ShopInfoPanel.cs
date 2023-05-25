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

    public void ShowShopItemInfo(ItemData ItemData)
    {
        infoText.text = "You wanna BUY the ItemData '" + ItemData.name + "' for " + ItemData.price + " coins?";
        yesButton.ItemData = ItemData;

        panelButtons.SetActive(true);
        yesButton.ShopButtonAction += ProcessBuyTransaction;
        noButton.ShopButtonAction += ProcessBuyTransaction;
    }

    public void ShowInventoryItemInfo(ItemData ItemData)
    {
        infoText.text = "You wanna SELL the ItemData '" + ItemData.name + "' for " + ItemData.price + " coins?";
        yesButton.ItemData = ItemData;

        panelButtons.SetActive(true);
        yesButton.ShopButtonAction += ProcessSellTransaction;
        noButton.ShopButtonAction += ProcessSellTransaction;
    }

    public void ProcessBuyTransaction(ItemData ItemData)
    {
        yesButton.ShopButtonAction -= ProcessBuyTransaction;
        noButton.ShopButtonAction -= ProcessBuyTransaction;

        if (ItemData != null)
        {
            EconomyManager.Instance.BuyItem(ItemData);
        }
       
        EndTransaction();
    }

    public void ProcessSellTransaction(ItemData ItemData)
    {
        yesButton.ShopButtonAction -= ProcessSellTransaction;
        noButton.ShopButtonAction -= ProcessSellTransaction;

        if (ItemData != null)
        {
            EconomyManager.Instance.SellItem(ItemData);
        }
        
        EndTransaction();
    }

    public void EndTransaction()
    {
        panelButtons.SetActive(false);
        infoText.text = DEFAULT_TEXT;
    }

}
