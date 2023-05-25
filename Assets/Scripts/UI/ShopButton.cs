using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, IPointerClickHandler
{
    public delegate void ShopButtonActionHandler(Item item);
    public event ShopButtonActionHandler ShopButtonAction;

    public Item item = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        ShopButtonAction?.Invoke(item);
    }
}
