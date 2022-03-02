using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public string itemId;
    public FlowerData.FlowerType flowerType;
    Inventory inv;
    public List<FlowerData> items = new List<FlowerData>();
    public int amount;

    //Function for collecting inventory from the world
    public void CollectItems()
    {
        if (flowerType == FlowerData.FlowerType.Red || flowerType == FlowerData.FlowerType.Blue || flowerType == FlowerData.FlowerType.Yellow)
        {
            inv.AddItem(inv.currentItem); //add to inventory
        }
        else
        {
            int found = 0;
            int addIndex = 0;

            for (int i = 0; i < inv.inventory.Count; i++) //check the count of inventory in inventory
            {
                if (itemId == inv.inventory[i].ID)
                {
                    found = 1;
                    addIndex = i;
                    break;
                }
            }

            if (found == 1) //if found 1 item, add to amount
            {
                inv.inventory[addIndex].Amount += amount;
            }
            else
            {
                for (int i = 0; i < inv.inventory.Count; i++)
                {
                    if (itemId == inv.inventory[i].ID)
                    {
                        inv.inventory[i].Amount = amount;
                    }
                }
            }
        }

        Destroy(gameObject);
    }
}