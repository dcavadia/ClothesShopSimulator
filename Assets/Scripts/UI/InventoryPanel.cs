using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public GameObject slotsHolder;

    private List<InventorySlot> slots = new List<InventorySlot>();
    //private List<ItemData> items = new List<ItemData>();



    private ItemSlot selectedSlot;

    public EquipButton equipButton;
    public UnequipButton unequipButton;

    private void Start()
    {
        slots = slotsHolder.GetComponentsInChildren<InventorySlot>().ToList();
        Hide();
    }

    private void OnEnable()
    {
        PopulateInventorySlots();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
        }
    }

    public void PopulateInventorySlots()
    {
        int slotIndex = 0;

        foreach(KeyValuePair<string, Item> item in InventoryManager.Instance.GetPlayerItems().Where(x=> !x.Value.isEquipped))
        {
            slots[slotIndex].SetItem(item.Key, item.Value.data);
            slotIndex++;
        }
        // Clear left over slots
        for (int i = slotIndex; i < slots.Count; i++)
        {
            slots[i].ClearSlot();
        }
    }

    // Ignore this unless you do changes here
    #region Tools
    public void ShowEquipButton()
    {
        HideUnequipButton();
        equipButton.gameObject.SetActive(true);
    }

    public void HideEquipButton()
    {
        equipButton.gameObject.SetActive(false);
    }

    public void ShowUnequipButton()
    {
        HideEquipButton();
        unequipButton.gameObject.SetActive(true);
    }

    public void HideUnequipButton()
    {
        unequipButton.gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        UIManager.Instance.InventoryPanel.SelectSlot(null);
    }

    public ItemSlot GetSelectedSlot()
    {
        return selectedSlot;
    }

    public void SelectSlot(ItemSlot slot)
    {
        if (selectedSlot != null)
        {
            selectedSlot.SetSelected(false);
        }
        if(slot != null)
        {
            selectedSlot = slot;
            selectedSlot.SetSelected(true);
        }
      
    }
    #endregion

}