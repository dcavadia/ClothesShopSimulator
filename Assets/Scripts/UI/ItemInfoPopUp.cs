using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfoPopUp : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text price;

    public void SetUpItemInfo(ItemData ItemData)
    {
        itemName.text = ItemData.name;
        price.text = ItemData.price.ToString();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
