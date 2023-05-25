using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EquipPanel : MonoBehaviour
{
    // Just one equip slot for the moments
    public EquipSlot slot;
    private InventorySlot selectedSlot;

    private void Start()
    {
        PopulateEquipSlot();
    }

    private void PopulateEquipSlot()
    {
        KeyValuePair<string, Item> item = InventoryManager.Instance.GetPlayerItems().FirstOrDefault(x => x.Value.isEquipped);

        if(item.Key != null )
        {
            slot.SetItem(item.Key, item.Value.data);
        }
    }

    //CHECK THIS
    public void EquipItem()
    {
        // Swap
        if(slot.itemData != null)
        {
            InventoryManager.Instance.GetPlayerItems().FirstOrDefault(x => x.Key == slot.itemUid).Value.isEquipped = false;
        }

        ItemSlot itemSlot = UIManager.Instance.InventoryPanel.GetSelectedSlot();
        KeyValuePair<string, Item> item = InventoryManager.Instance.GetPlayerItems().FirstOrDefault(x => x.Key == itemSlot.itemUid);
        item.Value.isEquipped = true;
        slot.SetItem(item.Key, item.Value.data);

        UIManager.Instance.InventoryPanel.PopulateInventorySlots();
        UIManager.Instance.InventoryPanel.HideEquipButton();
        UIManager.Instance.InventoryPanel.SelectSlot(null);
        //refresh inventory
    }

    public void UnequipItem()
    {
        ItemSlot itemSlot = UIManager.Instance.InventoryPanel.GetSelectedSlot();
        KeyValuePair<string, Item> item = InventoryManager.Instance.GetPlayerItems().FirstOrDefault(x => x.Key == itemSlot.itemUid);

        item.Value.isEquipped = false;
        slot.ClearSlot();

        UIManager.Instance.InventoryPanel.PopulateInventorySlots();
        UIManager.Instance.InventoryPanel.HideUnequipButton();
        UIManager.Instance.InventoryPanel.SelectSlot(null);
        //refresh inventory
    }





    public ItemData GetSelectedItem()
    {
        return selectedSlot.itemData;
    }

    public void SelectSlot(InventorySlot slot)
    {
        if (selectedSlot != null)
        {
            selectedSlot.SetSelected(false);
        }

        selectedSlot = slot;
        selectedSlot.SetSelected(true);
    }
}
