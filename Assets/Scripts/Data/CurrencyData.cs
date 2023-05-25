using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyData", menuName = "Inventory/Currency")]
public class CurrencyData : ScriptableObject
{
    public int currencyAmount; // The amount of currency the player has

    // You can add additional properties or methods specific to currency if needed
}
