using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrigger : MonoBehaviour
{
    public GameObject spider;
    private SpiderAI spiderAI;
    private GameObject player;
    private PlayerController playerController;
    
    // Start is called before the first frame update. Makes sure the spider isn't active
    // and gets needed components.
    void Start()
    {
        spider.SetActive(false);
        spiderAI = spider.GetComponent<SpiderAI>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame.
    // Turns the spider off after it returns to its starting position.
    void Update() {
        if ((spiderAI.startPosition == spider.transform.position) && !spiderAI.movingDown) {
            spider.SetActive(false);
        }
    }

    // Sets the spider to active if the player enters this object's hitbox while they aren't sneaking.
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player" && playerController.moveSpeed != playerController.sneakSpeed) {
            spider.SetActive(true);
            spiderAI.movingDown = true;
        }
    }
}
