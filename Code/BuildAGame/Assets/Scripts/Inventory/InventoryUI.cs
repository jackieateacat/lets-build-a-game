using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Tooltip("Drag and drop here the UI element that contains the Item Slots.")]
    [SerializeField] private Transform itemSlotsTransform;

    [Tooltip("Add here a reference to the Item Slot prefab.")]
    [SerializeField] private GameObject itemSlotPrefab;

    public ItemSlot InstantiateSlot(Item item)
    {
        var itemSlot = Instantiate(itemSlotPrefab, itemSlotsTransform).GetComponent<ItemSlot>();
        itemSlot.AddItem(item);

        return itemSlot;
    }

    public IEnumerable<ItemSlot> GetAllSlots()
    {
        foreach (Transform child in itemSlotsTransform)
        {
            var itemSlot = child.gameObject.GetComponent<ItemSlot>();

            if (itemSlot != null)
            {
                yield return itemSlot;
            }
        }
    }
}