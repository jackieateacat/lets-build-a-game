using UnityEngine;

public class NPCInventoryManager : InventoryManager
{
    [Header("Action Verbs")]
    [Tooltip("Insert a verb associated with the corresponding action.")]
    [SerializeField] private string examineVerb;

    [Tooltip("Insert a verb associated with this action (from the point of view of the Player).")]
    [SerializeField] private string negotiateVerb;

    [Tooltip("Check this box if this script is attached to a Store, for example, and can carry an unlimited amount of every item.")]
    [SerializeField] private bool hasUnlimitedSpace;

    public override void ShowTooltip()
    {
        var verbs = new string[] { examineVerb, "None", negotiateVerb };
        itemTooltip.ShowTooltip(verbs);
    }

    public override bool CanCarry(ItemScriptable baseItem, int quantity)
    {
        if (hasUnlimitedSpace) return true;
        else
        {
            var item = GetItemByItemType(baseItem.ItemType);

            if (item != null) return item.Quantity + quantity <= baseItem.MaxQuantity;
            else return quantity <= baseItem.MaxQuantity;
        }
    }
}