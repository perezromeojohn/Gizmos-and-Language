using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    // private void onCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player") == true)
    //     {
    //         dialogueTrigger.StartDialogue();
    //     }
    // }

    // is trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            dialogueTrigger.StartDialogue();
        }
    }
}
