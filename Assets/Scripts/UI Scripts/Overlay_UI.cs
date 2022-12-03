using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay_UI : MonoBehaviour
{
    public GameObject[] heartsList;

    // Start is called before the first frame update
    void Start()
    {
        heartsList = GameObject.FindGameObjectsWithTag("Heart");
        ResetHealthDisplay();
    }

    // Makes all of the hearts visible
    public void ResetHealthDisplay() {
        foreach (GameObject heart in heartsList)
        {
            heart.SetActive(true);
        }
    }

    // Updates the number of hearts shown based on the value passed to it.
    public void UpdateHealthDisplay(int health) {
        for (int i = 0; i < heartsList.Length; i++) {
            if (i + 1 <= health) {
                heartsList[i].SetActive(true);
            } else {
                heartsList[i].SetActive(false);
            }
        }
    }
}
