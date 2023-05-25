using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, IPointerClickHandler
{
    public delegate void ShopButtonActionHandler(Item ItemData);
    public event ShopButtonActionHandler ShopButtonAction;

    public Item ItemData = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        ShopButtonAction?.Invoke(ItemData);
    }
}
