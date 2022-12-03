using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AI_Vertical : MonoBehaviour
{
    public float movementSpeed = 0.8f;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame. Sets direction of the enemy
    // based on the direction the sprite is facing.
    void Update()
    {
        if (spriteRenderer.flipX) {
            rigidBody.velocity = new Vector2(0f, movementSpeed);
        } else {
            rigidBody.velocity = new Vector2(0f, -movementSpeed);
        }
    }

    // Flip the direction of the enemy's sprite when it hits a wall or the player.
    void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.isTrigger && (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Solid")) {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            bool movingDown = animator.GetBool("movingDown");
            animator.SetBool("movingDown", !movingDown);
        }
    }
}
