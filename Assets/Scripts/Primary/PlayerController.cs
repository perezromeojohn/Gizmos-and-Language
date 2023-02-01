using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        // reset the static bools for movement
        SceneChanger.playerEntered = false;
        OverWorldSceneChanger.playerExited = false;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update() {
        // if (DialogueManager.GetInstance().dialogueIsPlaying)  {
        //     // get the player input component and disable it
        //     playerInput.enabled = false;
        // } else {
        //     playerInput.enabled = true;
        // }
        
        // // get the static bool from the scene changer
        // if (SceneChanger.playerEntered) {
        //     // disable the player input component
        //     playerInput.enabled = false;
        // } else {
        //     playerInput.enabled = true;
        // }
        // merge the two if statements
        if (DialogueManager.GetInstance().dialogueIsPlaying || SceneChanger.playerEntered || OverWorldSceneChanger.playerExited) {
            playerInput.enabled = false;
        } else {
            playerInput.enabled = true;
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if(movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success)
            {
                // Try to move in the x direction
                success = TryMove(new Vector2(movementInput.x, 0));

                if (!success)
                {
                    // Try to move in the y direction
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }

            animator.SetBool("isMoving", success);
        } else {
            animator.SetBool("isMoving", false);
        }

        if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime * collisionOffset
            );

        if(count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else {
            return false;
        }
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}