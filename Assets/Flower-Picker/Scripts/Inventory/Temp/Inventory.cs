using FlowerPicker.Player;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory References")] public List<FlowerData> inventory = new List<FlowerData>();
    public FlowerData selectedItem;
    public FlowerData currentItem;
    public GameObject slotPrefab;
    public Transform inventorySlotParent;

    public Button use, discard; //references to UI buttons

    [SerializeField] private FPSController player;
    [SerializeField] public bool showInventory = false;

    [Header("Inventory Variables")] public string[] enumTypesForItems;
    public TMP_Text itemText;
    public TMP_Text descriptionText;
    public TMP_Text amountText;
    public TMP_Text valueText;
    public Image icon;
    private GameObject mesh;
    public Transform dropLocation;
    public GameObject itemPrefab;

    public GameObject itemSelectedPanel;

    private void Start()
    {
        enumTypesForItems = new string[] { "Yellow", "Blue", "Pink" };
    }

    //For eating apples, using potions etc
    public void UseItem()
    {
        if (selectedItem.Amount <= 0)
        {
            inventory.Remove(selectedItem);
            Destroy(selectedItem.Icon.texture);
            itemSelectedPanel.SetActive(false);
        }
        else
        {
            DisplayItem(selectedItem);
        }
    }
    
    public void DisplayItem(FlowerData item) //Display in Inventory
    {
        selectedItem = item;
        itemSelectedPanel.SetActive(true);

        //Display information from ItemData
        itemText.text = selectedItem.Name;
        descriptionText.text = selectedItem.Description;
        amountText.text = selectedItem.Amount.ToString();
        valueText.text = selectedItem.Rarity.ToString();
        icon.sprite = selectedItem.Icon != null ? selectedItem.Icon : null;
        mesh = selectedItem.Mesh;

        use.onClick.AddListener(UseItem);
        discard.onClick.AddListener(DiscardItem);
    }
    
    public void DiscardItem() 
    {
        GameObject droppedItem =
            Instantiate(itemPrefab, dropLocation.position, Quaternion.identity); //instantiate item at drop location
        droppedItem.name = selectedItem.Name;
        inventory.Remove(selectedItem); //removes from inventory
        Destroy(selectedItem.Icon.texture);
    }

    public void UpdateInvVisuals()
    {
        inventory.Remove(selectedItem); //removes from inventory
        Destroy(selectedItem.Icon.texture);
    }

    public void ActivateInventory()
    {
        Button[] allChildren = inventorySlotParent.GetComponentsInChildren<Button>();
        for (int x = allChildren.Length - 1; x >= 0; x--)
        {
            Destroy(allChildren[x].gameObject);
        }

        foreach (FlowerData item in inventory)
        {
            //Inventory Button
            GameObject itemSlot = Instantiate(slotPrefab, inventorySlotParent); //Clone item at item slot
            Button itemButton = itemSlot.GetComponent<Button>();
            selectedItem = item;
            itemButton.onClick.AddListener(() => DisplayItem(item));
            SlotImage slotImage = itemSlot.GetComponent<SlotImage>();
            Image image = slotImage.image;
            if (image != null)
            {
                image.sprite = item.Icon;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ActivateInventory();
        }
    }

    public void FindItem(string itemName)
    {
        FlowerData foundItem = inventory.Find(findItem => findItem.Name == itemName);
    }

    public void AddItem(FlowerData item)
    {
        inventory.Add(item);
        FlowerData foundItem = inventory.Find(FindItem => FindItem.Name == item.Name);
    }

}