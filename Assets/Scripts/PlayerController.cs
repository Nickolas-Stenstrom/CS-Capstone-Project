using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public readonly float walkSpeed = 0.6f;
    public readonly float runSpeed = 0.9f;
    public readonly float sneakSpeed = 0.4f;

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    
    public string roomLocation;
    
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.freezeRotation = true;
    }

    // Runs on a fixed timer, regardless of framerate. Sets the movement speed and checks to see if movement is valid.
    private void FixedUpdate() {
        if (Input.GetKey(KeyCode.Space)) {
            moveSpeed = runSpeed;
        } else if (Input.GetKey(KeyCode.RightShift)) {
            moveSpeed = sneakSpeed;
        } else {
            moveSpeed = walkSpeed;
        }
        
        if(canMove) {
            // If movement input is not 0, try to move.
            if(movementInput != Vector2.zero){
                
                bool success = TryMove(movementInput);

                if(!success) {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }

                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

                            // Set animator values.

                if (movementInput.x !=0) {
                    animator.SetBool("isMovingHorizontal", true);
                }
                else if (movementInput.y > 0) {
                    animator.SetBool("isMovingUp", true);
                }
                else if (movementInput.y < 0) {
                    animator.SetBool("isMovingDown", true);
                }               
            } else {
                animator.SetBool("isMovingHorizontal", false);
                animator.SetBool("isMovingUp", false);
                animator.SetBool("isMovingDown", false);
            }

            // Set direction of sprite to movement direction.
            if(movementInput.x < 0) {
                spriteRenderer.flipX = true;
            } else if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
            }

        }
    }

    // Checks to see if movement is valid using Cast() on the player. Returns true if movement is valid and false if it isn't.
    private bool TryMove(Vector2 direction) {
        if(direction != Vector2.zero) {
            // Check for potential collisions
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

            if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            // Can't move if there's no direction to move in
            return false;
        }
        
    }

    // Gets the player's movement.
    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    // Sets the canMove parameter to lock or unlock player movement.
    public void SetCanMove(bool value) {
        if (value) {
            canMove = true;
        } else {
            canMove = false;
        }
    }

}
