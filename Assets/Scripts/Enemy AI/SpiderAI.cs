using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    public Vector3 startPosition;
    public Animator animator;
    public float movementSpeed = 0.01f;
    public bool movingDown;

    public GameObject spiderTrigger;
    public BoxCollider2D spiderTriggerBC;

    // Start is called before the first frame update. Gets all of the needed components
    // Sets movingDown to false.
    void Start()
    {
        movingDown = false;
        startPosition = transform.position;
        animator = GetComponent<Animator>();
        spiderTriggerBC = spiderTrigger.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    // The spider moves down when movingDown is true and it hasn't met the center of spiderTrigger's hitbox.
    // The spider moves up after it meets the center of spiderTrigger's hitbox.
    void Update()
    {
        if (movingDown && transform.position.y <= spiderTriggerBC.bounds.center.y) {
            movingDown = false;
            animator.SetBool("movingDown", false);
        }
        else if (movingDown) {
            transform.position = Vector2.MoveTowards(transform.position, spiderTriggerBC.bounds.center, movementSpeed);
            animator.SetBool("movingDown", true);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, movementSpeed / 2);
        }
    }

}
