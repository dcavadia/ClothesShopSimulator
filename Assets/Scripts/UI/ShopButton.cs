using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, IPointerClickHandler
{
    public delegate void ShopButtonActionHandler(ItemData ItemData);
    public event ShopButtonActionHandler ShopButtonAction;

    public ItemData ItemData = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        ShopButtonAction?.Invoke(ItemData);
    }
}
