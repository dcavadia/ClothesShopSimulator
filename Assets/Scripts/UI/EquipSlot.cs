using System.Collections;
using System.Collections.Generic;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (itemData != null)
        {
            // Toggle the selection state
            isSelected = !isSelected;

            UIManager.Instance.InventoryPanel.ShowUnequipButton();

            UIManager.Instance.InventoryPanel.SelectSlot(this);
            UpdateSlotColor();
        }
    }

    public override void SetSelected(bool selected)
    {
        isSelected = selected;
        UpdateSlotColor();
    }

    private void UpdateSlotColor()
    {
        slotImage.color = isSelected ? selectedColor : Color.white;
    }
}
