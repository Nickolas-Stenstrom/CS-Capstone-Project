using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    Logic for interactable objects that require a specific inventory object.
*/

public class InteractableDoor : MonoBehaviour
{
    private bool inRange;
    private bool isClosed;

    public Player globalPlayer;
    public Pickup_Item neededItem;
    public Animator animator;
    public PlayerController playerController;
    public Dialog_UI dialogUI;

    public string completed = "Chest opened!";

    // Start is called before the first frame update
    private void Start() {
        playerController = globalPlayer.GetComponent<PlayerController>();
        isClosed = true;
        animator = GetComponent<Animator>();
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
        } else if (inRange && isClosed && Input.GetKeyDown(KeyCode.E)) {
            TryOpen();
        }
    }

    /*
        Uses TryRemove() to see if the player has the needed item, displays a success message
        and animates the object if they do.
        If they don't have the item, a message is displayed showing the name of the needed item.
    */

    void TryOpen() {
        if (globalPlayer.inventory.TryRemove(neededItem.itemName)) {
            isClosed = false;
            animator.SetBool("isOpen", true);
            dialogUI.title.text = completed;
            StartCoroutine(Close());
        } else {
            dialogUI.title.text = "You need a " + neededItem.itemName + ".";
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

    // automatically closes out of the dialog after 2 seconds if interaction is successful.
    IEnumerator Close() {
        yield return new WaitForSeconds(2);
        dialogUI.ToggleDialog();
        playerController.SetCanMove(true);
    }
}
