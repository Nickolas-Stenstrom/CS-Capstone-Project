using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    bool inRange;
    public Dialog_UI dialogUI;
    public PlayerController playerController;
    public Inventory_UI inventoryUI;
    public GameObject winPanel;
    public string dialogText = "";

    public Pickup_Item neededItem3;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame. Disable's the dialog box when the player presses the E key.
    void Update()
    {
        if (inRange && dialogUI.dialogPanel.activeSelf && Input.GetKeyDown(KeyCode.E)) {
            playerController.SetCanMove(true);
            dialogUI.ToggleDialog();
            Time.timeScale = 1;
        }       
    }

    // Gives the player instructions on what to do if they don't have the right items to win the game.
    // If the player does have the right items to win, the win screen is displayed.
    void OnTriggerEnter2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            inRange = true;
            if (inventoryUI.inventoryPanel.activeSelf) {
                inventoryUI.ToggleInventory();
            }
            if (player.inventory.TryRemove(neededItem3.itemName)) {
                    Time.timeScale = 0;
                    winPanel.SetActive(true);
                }
                 else {
                    Time.timeScale = 0;
                    playerController.SetCanMove(false);
                    dialogUI.title.text = dialogText;
                    dialogUI.ToggleDialog();
                }

        }
    }

    // Sets inRange to false when the player leaves this object's hitbox.
    void OnTriggerExit2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            inRange = false;
        }
    }
}
