using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Game/Inventory")]
public class InventoryData : ScriptableObject
{
    public CurrencyData currency; // The currency scriptable object
    public ItemData[] items; // An array of item scriptable objects

    // You can add additional properties or methods to manage the inventory if needed
}