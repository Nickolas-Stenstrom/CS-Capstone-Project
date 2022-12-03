using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    public string roomName;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Sets the player's room location to this room.
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            playerController.roomLocation = roomName;
        }
    }

    // Clears the player's room location when they leave the room.
    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            playerController.roomLocation = "NONE";
        }
    }
}
