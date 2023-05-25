using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : ItemSlot, IPointerClickHandler
{
    private bool isSelected;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (itemData != null)
        {
            // Toggle the selection state
            isSelected = !isSelected;

            // Call the function in ShopPanel to show ItemData info
            UIManager.Instance.ShopPanel.shopInfoPanel.ShowShopItemInfo(itemData);
        }
    }
}
