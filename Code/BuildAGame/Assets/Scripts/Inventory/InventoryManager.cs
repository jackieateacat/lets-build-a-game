using UnityEngine;

public abstract class InventoryManager : MonoBehaviour
{
    [Tooltip("Place here the current inventory that should be on display.")]
    [SerializeField] private InventoryScriptable inventory;

    [Tooltip("Drag and drop here a reference to the corresponding Inventory Panel.")]
    [SerializeField] protected InventoryUI inventoryPanel;

    [Tooltip("Drag and drop here a reference to the Item Tooltip GameObject.")]
    [SerializeField] protected ItemTooltip itemTooltip;

    protected static Item selectedItem;

    public static Item SelectedItem => selectedItem;

    private void Start()
    {
        PopulateInventoryPanel();
        inventoryPanel.gameObject.SetActive(false);
    }

    public void SelectItem(string itemId)
    {
        foreach (var item in inventory.Items)
        {
            if (item.UniqueId == itemId) selectedItem = item;
        }
    }

    public Item AddItem(ItemScriptable baseItem, int quantity)
    {
        var item = GetItemByItemType(baseItem.ItemType);

        if (item == null) return AddNewItem(baseItem, quantity);
        else
        {
            item.ChangeQuantity(quantity);
            UpdateInventoryPanel(item);
            return item;
        }
    }

    public void RemoveItem(ItemScriptable baseItem, int quantity)
    {
        var item = AddItem(baseItem, -quantity);
        if (item.Quantity == 0) inventory.Items.Remove(item);
    }

    public bool HasItem(string itemId)
    {
        foreach (var item in inventory.Items)
        {
            if (item.UniqueId == itemId) return true;
        }
        return false;
    }

    public abstract void ShowTooltip();

    public abstract bool CanCarry(ItemScriptable baseItem, int quantity);

    protected Item GetItemByItemType(ItemType itemType)
    {
        foreach (var item in inventory.Items)
        {
            if (item.BaseItem.ItemType == itemType) return item;
        }
        return null;
    }

    private Item AddNewItem(ItemScriptable baseItem, int quantity = 1)
    {
        var newItem = new Item(baseItem, quantity);
        inventory.Items.Add(newItem);

        var itemSlot = inventoryPanel.InstantiateSlot(newItem);
        itemSlot.OnItemSelect += SelectItem;
        itemSlot.OnRightClick += ShowTooltip;

        return newItem;
    }

    private void PopulateInventoryPanel()
    {
        foreach (var item in inventory.Items)
        {
            if (item.Quantity > 0)
            {
                var itemSlot = inventoryPanel.InstantiateSlot(item);
                itemSlot.OnItemSelect += SelectItem;
                itemSlot.OnRightClick += ShowTooltip;
            }
        }
    }

    private void UpdateInventoryPanel(Item itemToUpdate)
    {
        foreach (var itemSlot in inventoryPanel.GetAllSlots())
        {
            if (itemSlot.ItemId == itemToUpdate.UniqueId)
            {
                if (itemToUpdate.Quantity > 0) itemSlot.UpdateQuantity(itemToUpdate.Quantity);
                else
                {
                    itemSlot.OnItemSelect -= SelectItem;
                    itemSlot.OnRightClick -= ShowTooltip;
                    Destroy(itemSlot.gameObject);
                }
            }
        }
    }
}