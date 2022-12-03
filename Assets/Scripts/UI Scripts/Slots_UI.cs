using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    Class used by the inventory UI to make the player's inventory visible.
*/

public class Slots_UI : MonoBehaviour
{
    public Image itemIcon;

    // Sets the sprite of the inventory item to the passed slot's icon, sets up the background color of the slot in the UI.
    public void SetItem(Inventory.Slot slot) {
        if (slot != null) {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
        }
    }

    // Sets the Slot's item icon to null, sets the background color of the slot in the UI.
    public void SetEmpty() {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
    }
}
