using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemSlot : MonoBehaviour
{
    public Image itemIcon;
    public Item item;

    protected virtual void Awake(){}
    public virtual void SetSelected(bool selected) { }

    public void SetItem(string uid, ItemData ItemData)
    {

        item = new Item(uid, ItemData);
        itemIcon.enabled = true;
        itemIcon.sprite = item.data.icon;
    }

    public void ClearSlot()
    {
        item = null;
        itemIcon.enabled = false;
        itemIcon.sprite = null;
    }
}
