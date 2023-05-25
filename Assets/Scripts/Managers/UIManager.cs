using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonComponent<UIManager>
{
    public GameObject UICanvas;
    public ShopPanel ShopPanel;
    public InventoryPanel InventoryPanel;
    public EquipPanel EquipPanel;


    public bool IsPanelOpen()
    {
        return ShopPanel.gameObject.activeSelf || InventoryPanel.gameObject.activeSelf;
    }

    public bool isShopPanelOpen()
    {
        return ShopPanel.gameObject.activeSelf;
    }

    public bool isInventoryPanelOpen()
    {
        return InventoryPanel.gameObject.activeSelf;
    }
}
