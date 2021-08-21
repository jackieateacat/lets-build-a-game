using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommerceUI : MonoBehaviour
{
    public event Action<int> OnDealClosed = delegate { };

    [Tooltip("Drag and drop here the Item Icon object present as a child of the current GameObject.")]
    [SerializeField] private Image itemIcon;

    [Tooltip("Drag and drop here a reference to the Close Deal Button.")]
    [SerializeField] private Button closeDealButton;

    [Tooltip("Drag and drop here the Quantity Text object present as a child of the current GameObject.")]
    [SerializeField] private TextMeshProUGUI quantityText;

    private int currentQuantity;
    private int maxQuantity;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void LoadItem(Item item, string verb)
    {
        itemIcon.sprite = item.BaseItem.Icon;
        quantityText.text = "0";
        currentQuantity = 0;
        maxQuantity = item.Quantity;
        closeDealButton.GetComponentInChildren<TextMeshProUGUI>().text = verb;
    }

    public void CloseDeal()
    {
        if (currentQuantity > 0)
        {
            OnDealClosed(currentQuantity);
        }
    }

    public void AddQuantity()
    {
        ChangeQuantity(1);
    }

    public void RemoveQuantity()
    {
        ChangeQuantity(-1);
    }

    private void ChangeQuantity(int amount)
    {
        currentQuantity = Mathf.Clamp(currentQuantity + amount, 0, maxQuantity);
        quantityText.text = currentQuantity.ToString();
    }
}