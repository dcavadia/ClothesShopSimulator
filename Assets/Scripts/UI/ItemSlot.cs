using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemSlot : MonoBehaviour
{
    public Image itemIcon;
    public Item itemData;

    protected virtual void Awake()
    {

    }

    public void SetItem(Item item)
    {
        itemData = item;
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
