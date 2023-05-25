using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public GameObject slotsHolder;

    private List<ItemSlot> slots = new List<ItemSlot>();
    private List<ItemData> items = new List<ItemData>();


    void Start()
    {
        slots = slotsHolder.GetComponentsInChildren<ItemSlot>().ToList();
        PopulateInventorySlots();
    }

    void PopulateInventorySlots()
    {
        items = InventoryManager.Instance.GetPlayerItems();
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < items.Count)
            {
                slots[i].SetItem(items[i]);
            }
            else
            {
                // If there are no more items to sell, clear the slot
                slots[i].ClearSlot();
            }
        }
    }
}
