using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update() {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && !Pause.isPaused) {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // get the player tag
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            visualCue.SetActive(true);

            // LeanTween position of visual cue to y 0.25f
            LeanTween.moveLocalY(visualCue, 0.25f, 0.3f).setEaseInOutExpo();
            // LeanTween scale of visual cue to 1
            LeanTween.scale(visualCue, Vector3.one, 0.3f).setEaseInOutExpo();         

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // get the player tag
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            // LeanTween position of visual cue to y 0.25f
            LeanTween.moveLocalY(visualCue, 0.0f, 0.3f).setEaseInOutExpo();
            // LeanTween scale of visual cue to 1
            LeanTween.scale(visualCue, Vector3.zero, 0.3f).setEaseInOutExpo().setOnComplete(() => visualCue.SetActive(false));
        }
    }
}
