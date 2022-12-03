using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script for handling the Pause UI behavior.
*/

public class Pause_UI : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject confirmPanel;
    public GameObject controlsPanel;

    public GameObject dialogPanel;
    public GameObject inputPanel;
    public Inventory_UI inventoryUI;

    public GameObject winPanel;

    // Start is called before the first frame update.
    // Makes sure each panel of the pause screen is disabled on start up.
    private void Start()
    {
        pausePanel.SetActive(false);
        confirmPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    // Update is called once per frame. Toggles pause menu if the escape key is pressed and 
    // no other dialog boxes are open.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !dialogPanel.activeSelf && !inputPanel.activeSelf && !winPanel.activeSelf) {
            TogglePauseUI();
        } 
    }

    // Turns on and off the pause menu.
    // If the pause menu is turned off, the other menus are also turned off.
    // When the pause menu is turned on, the inventory UI is turned off it is active.
    public void TogglePauseUI() {
        if (pausePanel.activeSelf) {
            pausePanel.SetActive(false);
            confirmPanel.SetActive(false);
            controlsPanel.SetActive(false);
            Time.timeScale = 1;
        } else {
            if (inventoryUI.inventoryPanel.activeSelf) {
                inventoryUI.ToggleInventory();
            }
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // The function used by the pause button. 
    public void PauseButton() {
        if (!dialogPanel.activeSelf && !inputPanel.activeSelf) {
            TogglePauseUI();
        }
    }

    // Toggles the menu that asks the player to confirm if they want to quit.
    public void ToggleConfirmUI() {
        if (confirmPanel.activeSelf) {
            confirmPanel.SetActive(false);
        } else {
            confirmPanel.SetActive(true);
        }
    }

    // Toggles the controls menu.
    public void ToggleControlsUI() {
        if (controlsPanel.activeSelf) {
            controlsPanel.SetActive(false);
        } else {
            controlsPanel.SetActive(true);
        }
    }
}
