using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
    Holds references to the Dialog UI
*/
public class Dialog_UI : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI title;

    // Start is called before the first frame update
    void Start() {
        dialogPanel.SetActive(false);
    }

    // Turns the visibility of the UI on and off.
    public void ToggleDialog() {
        if (!dialogPanel.activeSelf) {
            dialogPanel.SetActive(true);
        } else {
            dialogPanel.SetActive(false);
        }
    }
}
