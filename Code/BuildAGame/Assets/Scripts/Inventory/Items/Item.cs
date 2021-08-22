using System;
using UnityEngine;

[System.Serializable]
public class Item
{
    [Tooltip("Add here the item you want to include.")]
    [SerializeField] private ItemScriptable baseItem;

    [Tooltip("The current available quantity of this item. Note that unless in a Store, this should be less or equal than the max quantity of the Base Item.")]
    [SerializeField] private int quantity;

    private string uniqueId;

    public ItemScriptable BaseItem => baseItem;
    public int Quantity => quantity;
    public int TotalWeight => quantity * baseItem.Weight;

    public string UniqueId => uniqueId == string.Empty
                                ? uniqueId = Guid.NewGuid().ToString()
                                : uniqueId;

    public Item(ItemScriptable baseItem, int quantity)
    {
        this.baseItem = baseItem;
        this.quantity = quantity;
        uniqueId = Guid.NewGuid().ToString();
    }

    public void ChangeQuantity(int amount)
    {
        quantity = Mathf.Max(quantity + amount, 0);
    }
}