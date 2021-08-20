using UnityEngine;

public class PlayerInventoryManager : InventoryManager
{
    [Header("Action Verbs")]
    [Tooltip("Insert a verb associated with the corresponding action.")]
    [SerializeField] private string examineVerb;

    [Tooltip("Insert a verb associated with the corresponding action.")]
    [SerializeField] private string useVerb;

    [Tooltip("Insert a verb associated with this action (from the point of view of the Player).")]
    [SerializeField] private string negotiateVerb;

    public override void ShowTooltip()
    {
        var verbs = IsNegotiating()
            ? new string[] { examineVerb, "None", negotiateVerb }
            : new string[] { examineVerb, useVerb, "None" };

        itemTooltip.ShowTooltip(verbs);
    }

    public override bool CanCarry(ItemScriptable baseItem, int quantity)
    {
        var item = GetItemByItemType(baseItem.ItemType);

        if (item != null) return item.Quantity + quantity <= baseItem.MaxQuantity;
        else return quantity <= baseItem.MaxQuantity;
    }

    //
    // The following methods have only placeholder implementations
    public void ExamineItem()
    {
        if (selectedItem != null) print(selectedItem.BaseItem.Description);
    }

    public void UseItem()
    {
        if (selectedItem != null) print($"Using {selectedItem.BaseItem.ItemName}...");
    }

    // This is only a very temporary and convoluted way of figuring out if we are
    // currently in a shop or during "regular" gameplay mode
    private bool IsNegotiating()
    {
        var inventoryUIs = FindObjectsOfType<InventoryUI>();

        foreach (var inventoryUI in inventoryUIs)
        {
            if (inventoryUI.gameObject != inventoryPanel.gameObject)
                return inventoryUI.gameObject.activeSelf;
        }

        return false;
    }
}