using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string uid;
    public ItemData data;
    public bool isEquipped;
    //int index;

    public Item(string uid, ItemData data)
    {
        this.uid = uid;
        this.data = data;
        isEquipped =  false;
    }
}
