using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Game/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int price;
    public bool isEquipped;

    // Here should be the type of item but since all of them are skins, show the sprites field of the skin for all items:
    public Sprite[] sprites;
}
