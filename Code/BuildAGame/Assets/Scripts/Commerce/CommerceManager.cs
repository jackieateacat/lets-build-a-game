using UnityEngine;

public class CommerceManager : MonoBehaviour
{
    [Tooltip("Drag and drop here a reference to the Commerce Panel GameObject.")]
    [SerializeField] private CommerceUI commercePanel;

    [Tooltip("Insert a verb associated with the corresponding action.")]
    [SerializeField] private string buyVerb;

    [Tooltip("Insert a verb associated with the corresponding action.")]
    [SerializeField] private string sellVerb;

    private Item itemToNegotiate;
    private InventoryManager buyer;
    private InventoryManager seller;
    private string negotiateVerb;

    private void Start()
    {
        commercePanel.OnDealClosed += CloseDeal;
    }

    public void NegotiateItem()
    {
        if (InventoryManager.SelectedItem != null)
        {
            itemToNegotiate = InventoryManager.SelectedItem;
            SetUpParties();
            commercePanel.gameObject.SetActive(true);
            commercePanel.LoadItem(itemToNegotiate, negotiateVerb);
        }
    }

    public void CloseDeal(int quantity)
    {
        if (itemToNegotiate != null)
        {
            if (buyer.CanCarry(itemToNegotiate.BaseItem, quantity))
            {
                buyer.AddItem(itemToNegotiate.BaseItem, quantity);
                seller.RemoveItem(itemToNegotiate.BaseItem, quantity);
                commercePanel.gameObject.SetActive(false);
            }
            else
            {
                print($"You can only carry {itemToNegotiate.BaseItem.MaxQuantity} of this item!");
            }
        }
    }

    private void SetUpParties()
    {
        var playerInventory = GetComponent<PlayerInventoryManager>();

        if (playerInventory.HasItem(itemToNegotiate.UniqueId))
        {
            buyer = FindObjectOfType<NPCInventoryManager>();
            seller = playerInventory;
            negotiateVerb = sellVerb;
        }
        else
        {
            buyer = playerInventory;
            seller = FindObjectOfType<NPCInventoryManager>();
            negotiateVerb = buyVerb;
        }
    }
}