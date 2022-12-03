using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Handles the logic for the Inventory UI
*/

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public PlayerController playerController;
    public Player player;
    public List<Slots_UI> slots = new List<Slots_UI>();
    public Animator animator;

    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject dialogPanel;
    public GameObject inputPanel;

    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !pausePanel.activeSelf && !winPanel.activeSelf && !dialogPanel.activeSelf && !inputPanel.activeSelf) {
            ToggleInventory();
        }
        if (animator.GetBool("isDead") == true) {
            inventoryPanel.SetActive(false);
        }
    }

    // Turns the visibility of the UI on and off. If turned on, the inventory is set up.
    public void ToggleInventory() {
        if (!inventoryPanel.activeSelf) {
            inventoryPanel.SetActive(true);
            playerController.SetCanMove(false);
            Setup();
        } else {
            inventoryPanel.SetActive(false);
            playerController.SetCanMove(true);
        }       
    }

    // Sets up the inventory UI by reading the player's inventory.
    public void Setup() {
        if (player.inventory.slots.Count == slots.Count) {
            for (int i = 0; i < slots.Count; i++) {
                if (player.inventory.slots[i].itemType != CollectableType.NONE) {
                    slots[i].SetItem(player.inventory.slots[i]);
                } else {
                    slots[i].SetEmpty();
                }
            }
        }
    }
}
