using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public ItemData ItemData;
    public int quantity;
    public bool equipped; // Add this property
}
