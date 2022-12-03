using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for objects that display the same message each time they're interacted with.
public class Interactable : MonoBehaviour
{
    private bool inRange;
    public Dialog_UI dialogUI;
    public PlayerController playerController;
    public string dialogText = "";

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame.
    // If the player is in range and they press the E key while the dialog box is active, the
    // dialog box is turned off and the player is able to move again.

    // If the player is in range and they press the E key while the dialog box isn't active, the
    // dialog box is turned on and the player's movement is turned off.
    void Update()
    {
        if (inRange && dialogUI.dialogPanel.activeSelf && Input.GetKeyDown(KeyCode.E)) {
            playerController.SetCanMove(true);
            dialogUI.ToggleDialog();
        }
        else if (inRange && !dialogUI.dialogPanel.activeSelf && Input.GetKeyDown(KeyCode.E)) {
            playerController.SetCanMove(false);
            dialogUI.title.text = dialogText;
            dialogUI.ToggleDialog();
        }
    }

    // Sets inRange to true if the player enters the object's hitbox.
    void OnTriggerEnter2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            inRange = true;
        }
    }

    // Sets inRange to false if the player leaves the object's hitbox.
    void OnTriggerExit2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            inRange = false;
        }
    }
}
