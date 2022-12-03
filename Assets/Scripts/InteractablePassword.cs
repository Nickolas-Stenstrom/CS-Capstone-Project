using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    Logic for interactable objects that require a player inputed password.
*/

public class InteractablePassword : MonoBehaviour
{
    private bool inRange;
    private bool isClosed;
    public string password = "test";
    public string completed = "complete";
    public string initial = "initial";
    public string failed = "failed";


    public InputDialog_UI inputDialogBoxUI;
    public Player globalPlayer;
    public PlayerController playerController;
    public GameObject refObject;

    // Start is called before the first frame update
    void Start() {
        isClosed = true;
        playerController = globalPlayer.GetComponent<PlayerController>();
        refObject.SetActive(false);
    }

    /*
        Update is called once per frame. If the player is in range and tries to interact, open the input dialog box.
        When the player presses the return key, call TryOpen() to see if the player inputed password is valid.
    */

    void Update()
    {
        if (inRange && inputDialogBoxUI.inputPanel.activeSelf && Input.GetKeyDown(KeyCode.Return)) {
            TryUse();
        } else if (inRange && inputDialogBoxUI.inputPanel.activeSelf) {
            playerController.SetCanMove(false);
        } else if (inRange && isClosed && Input.GetKeyDown(KeyCode.E)) {
            inputDialogBoxUI.title.text = initial;
            inputDialogBoxUI.ToggleInput();
        }
    }

    /*
        Called when the player presses the Return key with the input dialog box open.
        If the player input matches the interactable object's password, display a success message,
        and call Close() to close the dialog box after two seconds.

        If the password is incorrect, display a failure message and give the player the option to try again.
    */

    void TryUse() {
        if (string.Compare(inputDialogBoxUI.inputField.text, password) == 0) {
            isClosed = false;
            inputDialogBoxUI.title.text = completed;
            if (tag == "Clock") {
                refObject.SetActive(true);
            }
        } else {
            inputDialogBoxUI.title.text = failed;
        }
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
