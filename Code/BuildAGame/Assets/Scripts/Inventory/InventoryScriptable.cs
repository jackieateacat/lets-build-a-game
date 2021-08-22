using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory System/Inventory")]
public class InventoryScriptable : ScriptableObject
{
    [Tooltip("Click + to include a new item to this inventory. Note: there should only be one item of any given item type.")]
    [SerializeField] private List<Item> items;

    public List<Item> Items => items;
}