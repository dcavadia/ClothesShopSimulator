using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : ItemSlot, IPointerClickHandler
{
    private bool isSelected;
    private Image slotImage;

    [SerializeField] private Color selectedColor;

    protected override void Awake()
    {
        base.Awake();
        slotImage = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item.data != null)
        {
            // Toggle the selection state
            isSelected = !isSelected;

            // Show the item information in the shop info panel
            UIManager.Instance.ShopPanel.shopInfoPanel.ShowShopItemInfo(item);

            // Select the current slot in the shop panel and deselect other panels
            UIManager.Instance.ShopPanel.SelectSlot(this);
            UIManager.Instance.InventoryPanel.SelectSlot(null);
            UIManager.Instance.EquipPanel.SelectSlot(null);

            // Update the slot color based on the selection state
            UpdateSlotColor();
        }
    }

    private void UpdateSlotColor()
    {
        slotImage.color = isSelected ? selectedColor : Color.white;
    }

    public override void SetSelected(bool selected)
    {
        isSelected = selected;
        UpdateSlotColor();
    }
}
