using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : SingletonComponent<InventoryManager>
{
    public PlayerData playerData;

    private void Start()
    {
        EconomyManager.Instance.SetInitialCoins(playerData.coins);
    }

    public List<ItemData> GetPlayerItems()
    {
        return playerData.items.ToList();
    }
}