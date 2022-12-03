using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public Player_Hit playerHit;

    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHit = player.GetComponent<Player_Hit>();
    }

    // If the player comes in contact with a health pickup item while their health is less than the max,
    // the player's health is increased by one, and the health pickup item is removed from the scene.
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && playerHit.health < playerHit.maxHealth) {
            playerHit.AddHealth();
            Destroy(this.gameObject);
        }
    }
}
