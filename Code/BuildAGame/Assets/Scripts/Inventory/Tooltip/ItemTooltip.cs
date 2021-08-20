using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour, IPointerExitHandler
{
    [Tooltip("Drag and drop here a reference to the Examine Button.")]
    [SerializeField] private Button examineButton;

    [Tooltip("Drag and drop here a reference to the Use Button.")]
    [SerializeField] private Button useButton;

    [Tooltip("Drag and drop here a reference to the Negotiate Button.")]
    [SerializeField] private Button negotiateButton;

    [Header("Colors")]
    [Tooltip("The color the text will display when this button is enabled.")]
    [SerializeField] private Color enabledTextColor;

    [Tooltip("The color the text will display when this button is disabled.")]
    [SerializeField] private Color disabledTextColor;

    [Header("Screen Positioning")]
    [Tooltip("Drag and drop here a reference to the canvas where this object resides.")]
    [SerializeField] private Canvas canvas;

    [Tooltip("Drag and drop here a reference to this object's Rect Transform.")]
    [SerializeField] private RectTransform tooltipTransform;

    [Tooltip("This will set the minimum distance to the edge of the screen.")]
    [SerializeField] private float offset;

    private void Start()
    {
        AddOnClickListeners();
        gameObject.SetActive(false);
    }

    public void ShowTooltip(string[] verbs)
    {
        transform.position = Input.mousePosition.GetPositionOnScreen(canvas, tooltipTransform, offset);
        gameObject.SetActive(true);
        SetInteractableButtons(verbs);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!eventData.pointerCurrentRaycast.isValid || eventData.pointerCurrentRaycast.gameObject.transform.parent != transform)
        {
            gameObject.SetActive(false);
        }
    }

    private void SetInteractableButtons(string[] verbs)
    {
        var buttons = new Button[] { examineButton, useButton, negotiateButton };

        for (int i = 0; i < buttons.Length; i++)
        {
            if (verbs[i] == "None")
            {
                buttons[i].interactable = false;
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().color = disabledTextColor;
            }
            else
            {
                buttons[i].interactable = true;
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().color = enabledTextColor;
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = verbs[i];
            }
        }
    }

    private void AddOnClickListeners()
    {
        var buttons = new Button[] { examineButton, useButton, negotiateButton };

        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => gameObject.SetActive(false));
        }

        var playerInventory = FindObjectOfType<PlayerInventoryManager>();
        var commerceManager = FindObjectOfType<CommerceManager>();

        if (playerInventory != null)
        {
            examineButton.onClick.AddListener(playerInventory.ExamineItem);
            useButton.onClick.AddListener(playerInventory.UseItem);
        }
        if (commerceManager != null)
        {
            negotiateButton.onClick.AddListener(commerceManager.NegotiateItem);
        }
    }
}