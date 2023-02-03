using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed;
    private bool isPlayerNearby = false;
    private int pointsIndex;
    [SerializeField] private SpriteRenderer NPC;
    // get the animator component
    [SerializeField] private Animator animator;
    // get the walk animation
    [SerializeField] private AnimationClip walkAnimation;
    [SerializeField] private AnimationClip idleAnimation;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToWaypoint();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isPlayerNearby = true;
        }
    }

    // on trigger exit
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            isPlayerNearby = false;
        }
    }


    private void MoveToWaypoint() {
        if (pointsIndex <=  waypoints.Length - 1 && !isPlayerNearby) {
            animator.Play(walkAnimation.name);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            // if the the npc is moving left, flip the sprite
            if (transform.position.x < waypoints[pointsIndex].transform.position.x) {
                // flip
                NPC.flipX = false;
            } else {
                NPC.flipX = true;
            }
            
            if (transform.position == waypoints[pointsIndex].transform.position) {
                pointsIndex += 1;
            }
        } else if (isPlayerNearby) {
            // stop the npc
            transform.position = transform.position;
            animator.Play(idleAnimation.name);
        } else {
            pointsIndex = 0;
        }
    }
}
