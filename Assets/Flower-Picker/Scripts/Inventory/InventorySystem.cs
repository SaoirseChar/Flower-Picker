using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    private List<FlowerData> flowerList;

    public InventorySystem()
    {
        flowerList = new List<FlowerData>();
        
        Add(ScriptableObject.CreateInstance<FlowerData>());
        Debug.Log(flowerList.Count);
    }

    public void Add(FlowerData item)
    {
        flowerList.Add(item);
    }

    public List<FlowerData> GetFlowers()
    {
        return flowerList;
    }
}
