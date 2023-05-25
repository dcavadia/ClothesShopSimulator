using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : SingletonComponent<EconomyManager>
{
    private float coins = 0f;

    public delegate void ItemActionHandler();
    public event ItemActionHandler ItemAction;

    public void SetInitialCoins(float amount)
    {
        coins = amount;
    }

    public bool CanAffordItem(float cost)
    {
        return coins >= cost;
    }

    public void BuyItem(ItemData ItemData)
    {
        coins -= ItemData.price;
        ItemAction?.Invoke();
    }

    public void SellItem(ItemData ItemData)
    {
        coins += ItemData.price;
        ItemAction?.Invoke();
    }

    public void AddCoin(ItemData ItemData)
    {
        coins += ItemData.price;
    }

    public float GetPlayerCoins()
    {
        return coins;
    }
}
