using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Flower Data")]
public class FlowerData : ScriptableObject
{
    [Tooltip("Reference to flower")] public string id;
    [Tooltip("The name of the flower")] public string displayName;
    [Tooltip("Icon image for flower")] public Sprite icon;
    [Tooltip("Flower object")] public GameObject flowerPrefab;
}