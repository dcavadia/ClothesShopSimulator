using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public GameObject slotsHolder;
    public GameObject iconGhost;
    public ItemInfoPopUp itemInfoPopUp;
    public ShopInfoPanel shopInfoPanel;
    public List<ItemData> itemsToSell;

    private List<ItemSlot> slots = new List<ItemSlot>();

    private ItemSlot selectedSlot;

    private void Start()
    {
        slots = slotsHolder.GetComponentsInChildren<ItemSlot>().ToList();
        Hide();
    }

    private void OnEnable()
    {
        PopulateShopSlots();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
        }
    }

    // Populates the shop slots with items to sell.
    private void PopulateShopSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < itemsToSell.Count)
            {
                slots[i].SetItem("", itemsToSell[i]);
            }
            else
            {
                // If there are no more items to sell, clear the slot.
                slots[i].ClearSlot();
            }
        }
    }

    // Shows the shop panel.
    public void Show()
    {
        gameObject.SetActive(true);
    }

    // Hides the shop panel.
    public void Hide()
    {
        gameObject.SetActive(false);
        shopInfoPanel.EndTransaction(null);
        UIManager.Instance.InventoryPanel.SelectSlot(null);
    }

    // Selects a slot in the shop panel.
    public void SelectSlot(ItemSlot slot)
    {
        if (selectedSlot != null)
        {
            selectedSlot.SetSelected(false);
        }

        selectedSlot = slot;

        if (selectedSlot != null)
        {
            selectedSlot.SetSelected(true);
        }
    }
}
