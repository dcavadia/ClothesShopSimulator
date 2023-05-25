using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemSlot : MonoBehaviour
{
    public Image itemIcon;
    public ItemData itemData;
    public string itemUid;

    protected virtual void Awake()
    {

    }

    public void SetItem(string uid, ItemData ItemData)
    {
        itemUid = uid;
        itemData = ItemData;
        itemIcon.enabled = true;
        itemIcon.sprite = itemData.icon;
    }

    public void ClearSlot()
    {
        itemUid = "";
        itemData = null;
        itemIcon.enabled = false;
        itemIcon.sprite = null;
    }

    public virtual void SetSelected(bool selected)
    {

    }
}
