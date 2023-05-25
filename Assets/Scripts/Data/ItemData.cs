using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Game/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int price;
    public bool isEquipped;
    // Add any additional properties or methods here
}
