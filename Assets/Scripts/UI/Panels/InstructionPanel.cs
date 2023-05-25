using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPanel : MonoBehaviour
{
    public GameObject ShopInstruction;
    public GameObject InventoryInstruction;

    public void ShowShopInstruction()
    {
        ShopInstruction.SetActive(true);
    }

    public void HideShopInstruction()
    {
        ShopInstruction.SetActive(false);
    }
}
