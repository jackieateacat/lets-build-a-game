using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory System/Item")]
public class ItemScriptable : ScriptableObject
{
    [Tooltip("The Item Type defines how an item shall be grouped.")]
    [SerializeField] private ItemType itemType;

    [Tooltip("What is the name of this item? This is more specific than the Item Type.")]
    [SerializeField] private string itemName;

    [Tooltip("This short description can be used when the Player examines this item.")]
    [TextArea(5, 30)]
    [SerializeField] private string description;

    [Tooltip("How much one unit of this item weights.")]
    [SerializeField] private int weight;

    [Tooltip("How many of this item can be carried by the Player at once.")]
    [Range(1, 999)]
    [SerializeField] private int maxQuantity;

    [Tooltip("An icon to be represent this item in the Inventory.")]
    [SerializeField] private Sprite icon;

    public ItemType ItemType => itemType;
    public string ItemName => itemName;
    public string Description => description;
    public int Weight => weight;
    public int MaxQuantity => maxQuantity;
    public Sprite Icon => icon;
}