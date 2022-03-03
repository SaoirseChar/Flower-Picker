using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Flower Data")]
public class FlowerData : ScriptableObject
{
    [Tooltip("Reference to flower")] public int id;
    [Tooltip("The name of the flower")] public string displayName;

    [Tooltip("The description of the flower"), TextArea(15, 20)]
    public string description;

    [Tooltip("How rare the flower is")] public int rarity;
    public int amount;
    [Tooltip("Icon image for flower")] public Sprite icon;
    [Tooltip("Type of flower")]public FlowerTypes type;
    [Tooltip("Flower object")] public GameObject flowerPrefab;
    public bool Stackable { get; set; }
    
    public bool showInInventory = true;

    // Called when the item is pressed in the inventory
    public virtual void Use ()
    {
        // Use the item
        // Something may happen
    }

    // Call this method to remove the item from inventory
    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
}