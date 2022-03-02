using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Flower Data")]
public class FlowerData : ScriptableObject
{
    [Tooltip("Reference to flower")] public string id;
    [Tooltip("The name of the flower")] public string displayName;
    [Tooltip("The description of the flower")] public string description;
    [Tooltip("How rare the flowe is")] public int rarity;
    [Tooltip("Icon image for flower")] public Sprite icon;
    [Tooltip("Flower object")] public GameObject flowerPrefab;

    public enum FlowerType
    {
        Red,
        Yellow,
        Blue,
        Pink,
    }

    public FlowerType flowerType;
    public int amount;
    
    public string ID //allowing id to be modified outside script
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public int Rarity
    {
        get { return rarity; }
        set { rarity = value; }
    }

    public int Amount
    {
        get { return amount; }
        set { amount = value; }
    }

    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    public GameObject Mesh
    {
        get { return flowerPrefab; }
        set { flowerPrefab = value; }
    }

    public FlowerType Type
    {
        get { return flowerType; }
        set { flowerType = value; }
    }
}