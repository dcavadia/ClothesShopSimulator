using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonComponent<UIManager>
{
    public GameObject UICanvas;
    public ShopPanel ShopPanel;
    public InventoryPanel InventoryPanel;
    public EquipPanel EquipPanel;

}
