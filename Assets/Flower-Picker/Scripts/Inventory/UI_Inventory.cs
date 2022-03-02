using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private InventorySystem inv;
    private Transform itemSlotContainer;
    private Transform slotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        slotTemplate = itemSlotContainer.Find("SlotTemplate");
    }


    public void SetInventory(InventorySystem inv)
    {
        this.inv = inv;
    }

    public void RefreshInventory()
    {
        foreach (FlowerData flower in inv.GetFlowers())
        {
            RectTransform itemSlotTransform = Instantiate(slotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotTransform.gameObject.SetActive(true);
        }
    }
}
