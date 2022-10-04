using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public PlayerController playerController;
    public Inventory_UI inventoryUI;
    public GameOver_UI gameOverUI;

    public int maxHealth = 3;
    public int health;
    public int thrust = 2;
    public float knockbacktime = 0.15f;

    // Runs on the first frame
    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = 3;
    }

    // Subtracts one from the player's health, calls death animation if health reaches 0 or below.
    public void TakeDamage() {
        health--;
        if (health <= 0) {
            playerController.SetCanMove(false);
            animator.SetBool("isDead", true);
        }
    }

    /*
        Checks to see if the player collides with an enemy.
        If they do, find the difference between the player and enemy position, and 
        apply force to the player's rigid body, start KnockbackCo().
    */

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            playerController.SetCanMove(false);
            rb.isKinematic = false;
            Rigidbody2D enemyRB = collision.GetComponent<Rigidbody2D>();

            Vector2 difference = transform.position - enemyRB.transform.position;
            difference = difference.normalized * thrust;

            if (enemyRB.transform.position.y + 0.08f > transform.position.y) {
                difference = difference * -0.6f;
            }

            rb.AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(KnockbackCo());
        }
    }

    // Applies knockback force to the player for a set amount of time.
    private IEnumerator KnockbackCo() {
        yield return new WaitForSeconds(knockbacktime);
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        if (!inventoryUI.inventoryPanel.activeSelf){
            playerController.SetCanMove(true);
        }
        TakeDamage();
    }

    // Ends the game.
    public void EndGame() {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    // Repositions the player from the starting position, sets health to max.
    public void RetryGame() {
        animator.SetBool("isDead", false);
        health = maxHealth;
        transform.position = new Vector3(0, 0, 0);
        playerController.SetCanMove(true);
        gameOverUI.ToggleUI();
    }
}