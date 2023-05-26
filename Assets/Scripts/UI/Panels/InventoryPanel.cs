using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public GameObject slotsHolder;

    private List<ItemSlot> slots = new List<ItemSlot>();
    private ItemSlot selectedSlot;

    public EquipButton equipButton;
    public UnequipButton unequipButton;

    private void Start()
    {
        // Retrieve all ItemSlots from the slotsHolder
        slots = slotsHolder.GetComponentsInChildren<ItemSlot>().ToList();

        if (equipButton != null)
            Hide();
    }

    private void OnEnable()
    {
        PopulateInventorySlots();
        EconomyManager.Instance.ItemAction += HandleItemBought;
    }

    private void OnDisable()
    {
        // Unsubscribe from the ItemBought event in EconomyManager
        EconomyManager.Instance.ItemAction -= HandleItemBought;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
        }
    }

    // Populate the inventory slots with items from the player's inventory
    public void PopulateInventorySlots()
    {
        int slotIndex = 0;

        // Iterate through each item in the player's inventory that is not equipped
        foreach (KeyValuePair<string, Item> item in InventoryManager.Instance.GetPlayerItems().Where(x => !x.Value.isEquipped))
        {
            slots[slotIndex].SetItem(item.Key, item.Value.data);
            slotIndex++;
        }

        // Clear leftover slots
        for (int i = slotIndex; i < slots.Count; i++)
        {
            slots[i].ClearSlot();
        }
    }

    // Show the equip button
    public void ShowEquipButton()
    {
        if (equipButton == null)
            return;

        HideUnequipButton();
        equipButton.gameObject.SetActive(true);
    }

    // Hide the equip button
    public void HideEquipButton()
    {
        equipButton.gameObject.SetActive(false);
    }

    // Show the unequip button
    public void ShowUnequipButton()
    {
        if (unequipButton == null)
            return;

        HideEquipButton();
        unequipButton.gameObject.SetActive(true);
    }

    // Hide the unequip button
    public void HideUnequipButton()
    {
        unequipButton.gameObject.SetActive(false);
    }

    // Show the inventory panel
    public void Show()
    {
        gameObject.SetActive(true);
    }

    // Hide the inventory panel
    public void Hide()
    {
        gameObject.SetActive(false);
        UIManager.Instance.InventoryPanel.SelectSlot(null);
    }

    // Get the selected item slot
    public ItemSlot GetSelectedSlot()
    {
        return selectedSlot;
    }

    // Select a slot in the inventory panel
    public void SelectSlot(ItemSlot slot)
    {
        if (selectedSlot != null)
        {
            selectedSlot.SetSelected(false);
        }

        if (slot != null)
        {
            selectedSlot = slot;
            selectedSlot.SetSelected(true);
        }
    }

    // Check if there is available capacity in the inventory
    public bool CapacityAvailable()
    {
        foreach (ItemSlot item in slots)
        {
            if (item.item == null)
            {
                return true;
            }
        }

        return false;
    }

    // Handle item bought event
    private void HandleItemBought()
    {
        PopulateInventorySlots();
    }
}
