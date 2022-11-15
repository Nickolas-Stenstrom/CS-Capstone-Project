using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup_Item : MonoBehaviour
{
    public CollectableType itemType;
    public string itemName;
    public Sprite icon;
    public Player globalPlayer;
    public PlayerController playerController;
    public Dialog_UI dialogUI;
    public GameObject pauseUI;

    private bool inRange;

    // Start is called before the first frame update
    private void Start() {
        playerController = globalPlayer.GetComponent<PlayerController>();
    }

    /*
        Update is called once per frame.
        If the player is in range and the E key is pressed while the dialog box isn't active, PickUp() is called.
        If the player is in range and the E key is pressed while the dialog box is active, remove object from
        the field and turn the dialog box off.
        If the pause UI is active, don't let the player pick up objects.
    */
    private void Update() {
        if (inRange && Input.GetKeyDown(KeyCode.E) && !dialogUI.dialogPanel.activeSelf && !pauseUI.activeSelf) {
            PickUp();
        } else if (inRange && Input.GetKeyDown(KeyCode.E) && dialogUI.dialogPanel.activeSelf) {
            dialogUI.ToggleDialog();
            Destroy(this.gameObject);
            playerController.SetCanMove(true);
        }
    }

    // Checks to see if player is in range.
    private void OnTriggerEnter2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            inRange = true;
        }
    }

    // Checks to see if the player is out of range.
    private void OnTriggerExit2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            inRange = false;
        }
    }

    /*
        Places the Pickup Item in the player's inventory and displays a dialog box
        with the name of the Pickup Item.
    */

    public void PickUp() {
        if (globalPlayer.inventory.size < 8)
        {
            playerController.SetCanMove(false);
            globalPlayer.inventory.Add(this);
            dialogUI.title.text = "Picked up " + itemName + ".";
            dialogUI.ToggleDialog();
        }
    }

}

/*
    Type for denoting the item type
*/

public enum CollectableType {
    NONE, REGULAR_ITEM, KEY_ITEM
}
