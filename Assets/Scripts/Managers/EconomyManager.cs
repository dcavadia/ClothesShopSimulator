using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : SingletonComponent<EconomyManager>
{
    private float coins = 0f;

    public void SetInitialCoins(int amount)
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
    }

    public void SellItem(ItemData ItemData)
    {
        coins += ItemData.price;
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
