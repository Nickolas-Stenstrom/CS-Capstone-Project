using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AI_Horizontal : MonoBehaviour
{
    public float movementSpeed = 0.8f;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame. Sets direction of the enemy
    // based on the direction the sprite is facing.
    void Update()
    {
        if (spriteRenderer.flipX) {
            rigidBody.velocity = new Vector2(movementSpeed, 0f);
        } else {
            rigidBody.velocity = new Vector2(-movementSpeed, 0f);
        }
    }

    // Flip the direction of the enemy's sprite when it hits a wall or the player.
    void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.isTrigger && (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Solid")) {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
