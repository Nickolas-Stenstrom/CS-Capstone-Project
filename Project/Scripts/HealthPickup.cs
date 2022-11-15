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

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && playerHit.health < playerHit.maxHealth) {
            playerHit.AddHealth();
            Destroy(this.gameObject);
        }
    }
}
