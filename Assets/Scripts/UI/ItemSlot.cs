using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemSlot : MonoBehaviour
{
    public Image itemIcon;
    public ItemData itemData;

    protected virtual void Awake()
    {

    }

    public void SetItem(ItemData ItemData)
    {
        itemData = ItemData;
        itemIcon.enabled = true;
        itemIcon.sprite = itemData.icon;
    }

    public void ClearSlot()
    {
        itemData = null;
        itemIcon.enabled = false;
        itemIcon.sprite = null;
    }
}
