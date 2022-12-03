using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    private GameObject player;
    private BoxCollider2D playerBC;
    private SpriteRenderer playerSR;
    private PlayerController playerController;

    private SpriteRenderer spriteRenderer;
    public Animator animator;

    private Vector3 startPosition;
    public float defaultMovementSpeed = 0.002f;
    public string roomLocation = "room1";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBC = player.GetComponent<BoxCollider2D>();
        playerSR = player.GetComponent<SpriteRenderer>();
        playerController = player.GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", false);

        startPosition = transform.position;
    }

    // Update is called once per frame. Moves the ghost towards the 
    // player or to its starting position based on the player's location.
    void Update()
    {
        if (roomLocation == playerController.roomLocation) {
            MoveTowardsPlayer();
            animator.SetBool("isMoving", true);
        }
        else if (transform.position != startPosition){
            if (startPosition.x < transform.position.x) {
                spriteRenderer.flipX = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, startPosition, defaultMovementSpeed);
        }
        else {
            // The ghost isn't moving, so set isMoving in the animator to false.
            animator.SetBool("isMoving", false);
        }
        
    }

    // Moves the ghost towards the player. The ghost's speed is based
    // on the player's facing direction and tbe player's movement speed.
    void MoveTowardsPlayer() {
        
        if (transform.position.x < player.transform.position.x) {
            spriteRenderer.flipX = true;
        }
        else {
            spriteRenderer.flipX = false;
        }

        float speed = defaultMovementSpeed;

        // Handles setting the movement speed if the player and ghost are facing each other.
        if (spriteRenderer.flipX == playerSR.flipX) {
            if (playerController.moveSpeed == playerController.sneakSpeed) {
                speed = speed / 3f;
            }
            else if (playerController.moveSpeed == playerController.walkSpeed) {
                speed = speed / 1.5f;
            }
        }
        // Handles setting the movement speed if the player and ghost are not facing each other.
        else if (playerController.moveSpeed == playerController.sneakSpeed) {
            speed = speed / 1.25f;
        }
        else if (playerController.moveSpeed == playerController.runSpeed) {
            speed = speed * 1.2f;
        }

        transform.position = Vector2.MoveTowards(transform.position, playerBC.bounds.center, speed);
    }
}
