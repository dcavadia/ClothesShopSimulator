using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Game/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int coins; // The amount of coins
    public ItemData[] items; // An array of item scriptable objects
    public int inventorySize;
}

