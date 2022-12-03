using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    Logic for interactable objects that require a specific inventory object.
*/

public class InteractableNeedsObject : MonoBehaviour
{
    private bool inRange;
    private bool isClosed;

    public Player globalPlayer;
    public Pickup_Item neededItem;
    public PlayerController playerController;
    public Dialog_UI dialogUI;
    public bool isComplete;

    public string initial = "test";
    public string completed = "test complete";

    // Start is called before the first frame update
    private void Start() {
        playerController = globalPlayer.GetComponent<PlayerController>();
        isComplete = false;
    }

    /*
        Update is called once per frame. Calls TryOpen() if the player is in range, and closes the dialog box
        if the player is trying to close it.
        If the pause UI is active, then close the dialog box.
    */

    void Update()
    {
        if (inRange && dialogUI.dialogPanel.activeSelf && Input.GetKeyDown(KeyCode.E)) {
            playerController.SetCanMove(true);
            dialogUI.ToggleDialog();
        }
         else if (inRange && dialogUI.dialogPanel.activeSelf) {
            playerController.SetCanMove(false);
        } else if (inRange && Input.GetKeyDown(KeyCode.E)) {
            TryUse();
        }
    }

    /*
        Uses TryRemove() to see if the player has the needed item, displays a success message
        and animates the object if they do.
        If they don't have the item, a message is displayed showing the name of the needed item.
    */

    void TryUse() {
        if (!this.isComplete) {
            if (globalPlayer.inventory.TryRemove(neededItem.itemName)) {
                this.isComplete = true;
            }
        }

        if (this.isComplete) {
            dialogUI.title.text = this.completed;
        }
        else {
            dialogUI.title.text = this.initial;
        }

        dialogUI.ToggleDialog();
    }

    // Sees if the player is in range
    void OnTriggerEnter2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            inRange = true;
        }
    }

    // Sees if the player is out of range.
    void OnTriggerExit2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            inRange = false;
        }
    }
}
