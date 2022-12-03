using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
    Handles controlling the fields of the Input Dialog UI Screen. 
*/

public class InputDialog_UI : MonoBehaviour
{
    public GameObject inputPanel;
    public PlayerController playerController;
    public TextMeshProUGUI title;
    public TMP_InputField inputField;

    private string defaultTitle = "This requires a password...";

    // Start is called before the first frame update
    void Start() {
        inputPanel.SetActive(false);
        inputField.characterLimit = 6;
    }

    // Turns the visibility of the UI on and off.
    public void ToggleInput() {
        if (!inputPanel.activeSelf) {
            inputPanel.SetActive(true);
            playerController.SetCanMove(false);
        } else {
            inputPanel.SetActive(false);
            Reset();
            playerController.SetCanMove(true);
        }       
    }

    // Resets the title of the UI to the default title.
    public void Reset() {
        title.text = defaultTitle;
        inputField.text = "";
    }
}
