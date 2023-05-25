using System.Collections;
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
    public List<Item> itemsToSell;

    private List<ItemSlot> slots = new List<ItemSlot>();


    // Start is called before the first frame update
    void Start()
    {
        slots = slotsHolder.GetComponentsInChildren<ItemSlot>().ToList();
        PopulateShopSlots();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PopulateShopSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < itemsToSell.Count)
            {
                slots[i].SetItem(itemsToSell[i]);
            }
            else
            {
                // If there are no more items to sell, clear the slot
                slots[i].ClearSlot();
            }
        }
    }
}
