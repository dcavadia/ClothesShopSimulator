using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : SingletonComponent<InventoryManager>
{
    public PlayerData playerData;

    private Dictionary<string, Item> inventoryItems = new Dictionary<string, Item>();

    private void Start()
    {
        EconomyManager.Instance.SetInitialCoins(playerData.coins);
        InitializeItems();
    }

    public void InitializeItems()
    {
        foreach(ItemData item in playerData.items.ToList())
        {
            Item newItem = new Item(Guid.NewGuid().ToString(), item);
            inventoryItems.Add(newItem.uid, newItem);
        }
    }

    // Buy item
    public void AddItemToInventory(ItemData item)
    {
        Item newItem = new Item(Guid.NewGuid().ToString(), item);
        inventoryItems.Add(newItem.uid, newItem);
    }

    // Sell item
    public void RemoveItemFromInventory(string itemUid)
    {    
        inventoryItems.Remove(itemUid);
    }

    public Dictionary<string, Item> GetPlayerItems()
    {
        return inventoryItems;
    }
}