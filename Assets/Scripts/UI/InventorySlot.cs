using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : ItemSlot, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    private bool isSelected;

    private GameObject iconGhost;

    protected override void Awake()
    {
        base.Awake();

        iconGhost = UIManager.Instance.ShopPanel.iconGhost;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (itemData != null)
        {
            // Toggle the selection state
            isSelected = !isSelected;

            // Call the function in ShopPanel to show item info
            UIManager.Instance.ShopPanel.shopInfoPanel.ShowInventoryItemInfo(itemData);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (itemData == null)
            return;

        iconGhost.GetComponent<Image>().sprite = itemIcon.sprite;
        iconGhost.transform.position = eventData.position;
        iconGhost.SetActive(true);
        itemIcon.enabled = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (itemData == null)
            return;

        iconGhost.SetActive(false);
        itemIcon.enabled = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemData == null)
            return;

        iconGhost.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (itemData == null)
            return;

        iconGhost.SetActive(false);
        itemIcon.enabled = true;
    }

    public void OnDrop(PointerEventData eventData)
    {

        InventorySlot sourceSlot = eventData.pointerDrag.GetComponent<InventorySlot>();
        InventorySlot destinationSlot = this;

        if (sourceSlot != null && sourceSlot.itemData != null && destinationSlot != null && sourceSlot != destinationSlot)
        {
            Item sourceItem = sourceSlot.itemData;
            if (destinationSlot.itemData == null)
            {
                // Move items between slots
                sourceSlot.ClearSlot();
                destinationSlot.SetItem(sourceItem);
                iconGhost.SetActive(false);
            }
            else
            {
                // Swap items between slots
                sourceSlot.SetItem(destinationSlot.itemData);
                destinationSlot.SetItem(sourceItem);
            }
        }
        else
        {
            Debug.Log("HUH!");
        }
    }
}
