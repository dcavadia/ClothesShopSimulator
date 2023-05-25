using System;
using System.Collections.Generic;
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
        foreach (ItemData item in playerData.items)
        {
            Item newItem = new Item(Guid.NewGuid().ToString(), item);
            inventoryItems.Add(newItem.uid, newItem);
        }
    }

    public void AddItemToInventory(ItemData item)
    {
        Item newItem = new Item(Guid.NewGuid().ToString(), item);
        inventoryItems.Add(newItem.uid, newItem);
    }

    public void RemoveItemFromInventory(string itemUid)
    {
        inventoryItems.Remove(itemUid);
    }

    // Retrieves the dictionary of the player's inventory items.
    public Dictionary<string, Item> GetPlayerItems()
    {
        return inventoryItems;
    }
}
