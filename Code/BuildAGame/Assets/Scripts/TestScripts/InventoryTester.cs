using UnityEngine;

public class InventoryTester : MonoBehaviour
{
    [SerializeField] protected Transform playerInventoryPanel;
    [SerializeField] protected Transform NPCInventoryPanel;

    private void Start()
    {
        print("Press I in the keyboard to toggle the Player Inventory on and off");
        print("Press SPACE to toggle the Store Inventory on and off");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerInventoryPanel.gameObject.SetActive(!playerInventoryPanel.gameObject.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NPCInventoryPanel.gameObject.SetActive(!NPCInventoryPanel.gameObject.activeSelf);
        }
    }
}