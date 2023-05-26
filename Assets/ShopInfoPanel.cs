using TMPro;
using UnityEngine;

public class ShopInfoPanel : MonoBehaviour
{
    private const string DEFAULT_TEXT = "Need some new clothing or accessories? Or are you looking to update your wardrobe?";

    public TMP_Text infoText;
    public GameObject panelButtons;
    public ShopButton yesButton;
    public ShopButton noButton;

    // Displays the information for a shop item.
    public void ShowShopItemInfo(Item itemData)
    {
        infoText.text = "You wanna BUY the item '" + itemData.data.name + "' for " + itemData.data.price + " coins?";
        yesButton.ItemData = itemData;

        panelButtons.SetActive(true);
        yesButton.ShopButtonAction += ProcessBuyTransaction;
        noButton.ShopButtonAction += EndTransaction;
    }

    // Displays the information for an inventory item.
    public void ShowInventoryItemInfo(Item itemData)
    {
        infoText.text = "You wanna SELL the item '" + itemData.data.name + "' for " + itemData.data.price + " coins?";
        yesButton.ItemData = itemData;

        panelButtons.SetActive(true);
        yesButton.ShopButtonAction += ProcessSellTransaction;
        noButton.ShopButtonAction += EndTransaction;
    }

    // Process the transaction for buying an item.
    private void ProcessBuyTransaction(Item itemData)
    {
        if (!EconomyManager.Instance.CanAffordItem(itemData.data.price) || !UIManager.Instance.InventoryPanel.CapacityAvailable())
        {
            Debug.Log("Not enough money or capacity");
            return;
        }

        yesButton.ShopButtonAction -= ProcessBuyTransaction;
        noButton.ShopButtonAction -= EndTransaction;

        if (itemData != null)
        {
            InventoryManager.Instance.AddItemToInventory(itemData.data);
            EconomyManager.Instance.BuyItem(itemData.data);     
        }

        EndTransaction(itemData);
    }

    // Process the transaction for selling an item.
    private void ProcessSellTransaction(Item itemData)
    {
        yesButton.ShopButtonAction -= ProcessSellTransaction;
        noButton.ShopButtonAction -= EndTransaction;

        if (itemData != null)
        {
            InventoryManager.Instance.RemoveItemFromInventory(itemData.uid);
            EconomyManager.Instance.SellItem(itemData.data);
        }

        EndTransaction(itemData);
    }

    // Ends the transaction and resets the panel to its default state.
    public void EndTransaction(Item itemData)
    {

        yesButton.ShopButtonAction -= ProcessBuyTransaction;
        yesButton.ShopButtonAction -= ProcessSellTransaction;
        noButton.ShopButtonAction -= EndTransaction;

        panelButtons.SetActive(false);
        infoText.text = DEFAULT_TEXT;
    }

    public void ResetSelectedItem()
    {
        panelButtons.SetActive(false);
        infoText.text = DEFAULT_TEXT;
    }
}
