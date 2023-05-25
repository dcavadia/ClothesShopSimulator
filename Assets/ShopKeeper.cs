using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    bool inRange;

    private void Update()
    {
        if (!inRange)
            return;

        if (Input.GetKeyDown(KeyCode.B))
        {
            UIManager.Instance.ShopPanel.Show();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>() != null)
        {
            inRange = true;
        }

        UIManager.Instance.InstructionPanel.ShowShopInstruction();
    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            inRange = false;
        }

        UIManager.Instance.InstructionPanel.HideShopInstruction();
    }
}
