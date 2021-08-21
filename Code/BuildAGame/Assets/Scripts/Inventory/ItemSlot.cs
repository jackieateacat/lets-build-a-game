using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerDownHandler, ISelectHandler, IDeselectHandler
{
    public event Action<string> OnItemSelect = delegate { };
    public event Action OnRightClick = delegate { };

    [Tooltip("The color to be tinted over the icon when the corresponding item is selected.")]
    [SerializeField] private Color selectedColor;

    private string itemId;
    private Image itemIcon;
    private TextMeshProUGUI quantityText;

    public string ItemId => itemId;

    private void Awake()
    {
        itemIcon = GetComponent<Image>();
        quantityText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void AddItem(Item item)
    {
        itemId = item.UniqueId;
        itemIcon.sprite = item.BaseItem.Icon;
        quantityText.text = item.Quantity.ToString();
    }

    public void UpdateQuantity(int quantity)
    {
        quantityText.text = quantity.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            eventData.selectedObject = gameObject;
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            eventData.selectedObject = gameObject;
            OnRightClick();
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        OnItemSelect(itemId);
        itemIcon.color = selectedColor;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //OnItemSelect(string.Empty);
        itemIcon.color = Color.white;
    }
}