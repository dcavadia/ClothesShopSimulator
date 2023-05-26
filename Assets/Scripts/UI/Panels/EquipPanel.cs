using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EquipPanel : MonoBehaviour
{
    public EquipSlot slot;
    public Image profilePicture;
    private InventorySlot selectedSlot;

    [SerializeField] private Color selectedColor;

    private void Start()
    {
        PopulateEquipSlot();
        SetProfilePicture();
    }

    // Populates the equip slot with the currently equipped item, if any
    private void PopulateEquipSlot()
    {
        KeyValuePair<string, Item> item = InventoryManager.Instance.GetPlayerItems().FirstOrDefault(x => x.Value.isEquipped);

        if (item.Key != null)
        {
            slot.SetItem(item.Key, item.Value.data);
        }
    }


    // Equips the selected item and updates UI accordingly
    public void EquipItem()
    {
        if (slot.item != null)
        {
            var equippedItem = InventoryManager.Instance.GetPlayerItems()
                .FirstOrDefault(x => x.Key == slot.item.uid);

            if (!equippedItem.Equals(default))
            {
                equippedItem.Value.isEquipped = false;
            }
        }

        ItemSlot itemSlot = UIManager.Instance.InventoryPanel.GetSelectedSlot();
        KeyValuePair<string, Item> selectedItem = InventoryManager.Instance.GetPlayerItems()
            .FirstOrDefault(x => x.Key == itemSlot.item.uid);

        if (!selectedItem.Equals(default))
        {
            selectedItem.Value.isEquipped = true;
            slot.SetItem(selectedItem.Key, selectedItem.Value.data);

            UIManager.Instance.InventoryPanel.PopulateInventorySlots();
            UIManager.Instance.InventoryPanel.HideEquipButton();
            UIManager.Instance.InventoryPanel.SelectSlot(null);

            PlayerCustomizationManager.Instance.SetSkin(selectedItem.Value.data);
            SetProfilePicture();
        }
    }

    // Sets the profile picture based on the current skin
    public void SetProfilePicture()
    {
        Sprite picture = PlayerCustomizationManager.Instance.GetSkinPicture();
        if (picture != null)
        {
            profilePicture.sprite = picture;
        }
    }

    // Unequips the selected item and updates UI accordingly
    public void UnequipItem()
    {
        if (!UIManager.Instance.InventoryPanel.CapacityAvailable())
        {
            return;
        }

        ItemSlot itemSlot = UIManager.Instance.InventoryPanel.GetSelectedSlot();
        KeyValuePair<string, Item> selectedItem = InventoryManager.Instance.GetPlayerItems()
            .FirstOrDefault(x => x.Key == itemSlot.item.uid);

        if (!selectedItem.Equals(default))
        {
            selectedItem.Value.isEquipped = false;
            slot.ClearSlot();

            UIManager.Instance.InventoryPanel.PopulateInventorySlots();
            UIManager.Instance.InventoryPanel.HideUnequipButton();
            UIManager.Instance.InventoryPanel.SelectSlot(null);

            PlayerCustomizationManager.Instance.RemoveSkin();
            SetProfilePicture();
        }
    }

    // Returns the data of the currently selected item, if any
    public ItemData GetSelectedItem()
    {
        return selectedSlot?.item.data;
    }

    // Selects the given inventory slot and updates UI accordingly
    public void SelectSlot(InventorySlot inventorySlot)
    {
        if (selectedSlot != null)
        {
            selectedSlot.SetSelected(false);
        }

        selectedSlot = inventorySlot;
        selectedSlot?.SetSelected(true);
    }
}
