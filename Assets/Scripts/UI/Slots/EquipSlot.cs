using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : ItemSlot, IPointerClickHandler
{
    private bool isSelected;
    private Image slotImage;

    [SerializeField] private Color selectedColor;

    protected override void Awake()
    {
        base.Awake();
        slotImage = GetComponent<Image>();
    }

    // Handle the click event when the equip slot is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item.data != null)
        {
            ToggleSelection();

            // Update UI states and colors
            UIManager.Instance.InventoryPanel.ShowUnequipButton();
            UIManager.Instance.InventoryPanel.SelectSlot(this);
            UIManager.Instance.ShopPanel.SelectSlot(null);
            UIManager.Instance.EquipPanel.SelectSlot(null);
            UpdateSlotColor();
        }
    }

    // Toggle the selection state of the equip slot
    private void ToggleSelection()
    {
        isSelected = !isSelected;
    }

    // Update the color of the equip slot based on its selection state
    private void UpdateSlotColor()
    {
        slotImage.color = isSelected ? selectedColor : Color.white;
    }

    // Set the selected state of the equip slot
    public override void SetSelected(bool selected)
    {
        isSelected = selected;
        UpdateSlotColor();
    }
}
