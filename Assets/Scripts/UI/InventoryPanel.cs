using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public GameObject slotsHolder;

    private List<ItemSlot> slots = new List<ItemSlot>();

    // Start is called before the first frame update
    void Start()
    {
        slots = slotsHolder.GetComponentsInChildren<ItemSlot>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
