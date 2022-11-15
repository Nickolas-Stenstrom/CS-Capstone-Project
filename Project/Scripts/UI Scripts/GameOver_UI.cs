using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Holds references to the Game Over UI
*/
public class GameOver_UI : MonoBehaviour
{
    public GameObject gameOverPanel;

    // Turns the visibility of the UI on and off.
    public void ToggleUI() {
        if (!gameOverPanel.activeSelf) {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        } else {
            Time.timeScale = 1;
            gameOverPanel.SetActive(false);
        }
    }
}
