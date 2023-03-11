using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // get the player tag
        if (collision.CompareTag("Player"))
        {
            // LeanTween visibility of door to 0
            // LeanTween.alpha(door, 0, 0.3f).setEaseInOutQuint();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // get the player tag
        if (collision.CompareTag("Player"))
        {
            // LeanTween visibility of door to 1
            // LeanTween.alpha(door, 1, 0.3f).setEaseInOutQuint();
        }
    }
}
