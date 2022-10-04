using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    CLass used for instantiating the player's inventory and holding
    a reference to it.
*/

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake() {
        inventory = new Inventory();
    }
}
