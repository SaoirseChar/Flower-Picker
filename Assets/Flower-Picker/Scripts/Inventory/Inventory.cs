using FlowerPicker.Player;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake ()
    {
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 10;	// Amount of item spaces

    // Our current list of items in the inventory
    public List<FlowerData> items = new List<FlowerData>();

    // Add a new item if enough room
    public void Add (FlowerData item)
    {
        if (item.showInInventory) {
            if (items.Count >= space) {
                Debug.Log ("Not enough room.");
                return;
            }

            items.Add (item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke ();
        }
    }

    // Remove an item
    public void Remove (FlowerData item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}