using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI actorMessage;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started Conversation, Loaded Messages: " + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage() {
        Message messageToDisplay = currentMessages[activeMessage];
        actorMessage.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }

    public void NextMessage() {
        activeMessage++;
        if (activeMessage < currentMessages.Length) {
            DisplayMessage();
        } else {
            Debug.Log("Conversation Ended");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
    }

    void AnimateTextColor() {
        // using text mesh pro, have a fade in whenever the text changes
        // LeanTween.value(gameObject, 0, 1, 0.5f).setOnUpdate((float val) => {
        //     actorMessage.color = new Color(0, 0, 0, val);
        // });

        // add wacky animation to the text when it changes
        actorMessage.transform.localScale = Vector3.zero * -1;
        LeanTween.scale(actorMessage.gameObject, Vector3.one, 0.5f).setEaseInOutExpo();
    }
    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // get e input
        if (Input.GetKeyDown(KeyCode.E) && isActive) {
            NextMessage();
        }
    }
}
