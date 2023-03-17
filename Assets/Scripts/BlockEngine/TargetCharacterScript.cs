using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCharacterScript : MonoBehaviour
{
    
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // custom collision box so it won't exceed the playing field
    [SerializeField] private GameObject CollisionBoundBox;

    public float delayTime = 0.1f; // adjust this to your desired delay time
    private Vector3 previousPosition;


    void Start()
    {
        previousPosition = transform.position;
        // debug if both the animator and sprite renderer are null
        if (animator == null || spriteRenderer == null)
        {
            Debug.LogError("Animator or Sprite Renderer is null");
        } else {
            Debug.Log("Animator and Sprite Renderer Present");
        }
    }

    // Update is called once per frame
    void Update() {
        // check if the gameobject has moved from its previous position
        if (transform.position != previousPosition)
        {
            // set the previous position to the current position of the gameobject
            previousPosition = transform.position;
            
            // play the walk animation here
            animator.Play("Justin_Walk");
        }
        else
        {
            // wait for a short delay before checking again
            StartCoroutine(DelayedIdleAnimation(delayTime));
        }
    }

    IEnumerator DelayedIdleAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);

        // check if the gameobject is still at the same position as the previous frame
        if (transform.position == previousPosition)
        {
            // play the idle animation here
            animator.Play("Justin_Idle");
        }
    }
}
