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

    public InputDialog_UI inputDialogBoxUI;
    public Player globalPlayer;
    public Animator animator;
    public PlayerController playerController;

    public string completed = "Chest opened!";

    // Start is called before the first frame update
    void Start() {
        isClosed = true;
        playerController = globalPlayer.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();

    }

    /*
        Update is called once per frame. If the player is in range and tries to interact, open the input dialog box.
        When the player presses the return key, call TryOpen() to see if the player inputed password is valid.
    */

    void Update()
    {
        if (inRange && inputDialogBoxUI.inputPanel.activeSelf && Input.GetKeyDown(KeyCode.Return)) {
            TryOpen();
        } else if (inRange && inputDialogBoxUI.inputPanel.activeSelf) {
            playerController.SetCanMove(false);
        } else if (inRange && isClosed && Input.GetKeyDown(KeyCode.E)) {
            inputDialogBoxUI.ToggleInput();
        }
    }

    /*
        Called when the player presses the Return key with the input dialog box open.
        If the player input matches the interactable object's password, display a success message,
        and call Close() to close the dialog box after two seconds.

        If the password is incorrect, display a failure message and give the player the option to try again.
    */

    void TryOpen() {
        if (string.Compare(inputDialogBoxUI.inputField.text, password) == 0) {
            isClosed = false;
            animator.SetBool("isOpen", true);
            inputDialogBoxUI.title.text = completed;
            StartCoroutine(Close());

        } else {
            inputDialogBoxUI.title.text = "Wrong password! Try again?";
        }
    }

    // automatically closes out of the dialog after 2 seconds if interaction is successful.
    IEnumerator Close() {
        yield return new WaitForSeconds(2);
        inputDialogBoxUI.ToggleInput();
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
