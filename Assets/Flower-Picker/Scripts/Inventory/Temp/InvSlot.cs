using UnityEngine;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    FlowerData item;	// Current item in the slot

    // Add item to the slot
    public void AddItem (FlowerData newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    // Clear the slot
    public void ClearSlot ()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    // If the remove button is pressed, this function will be called.
    public void RemoveItemFromInventory ()
    {
        Inventory.instance.Remove(item);
    }

    // Use the item
    public void UseItem ()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
