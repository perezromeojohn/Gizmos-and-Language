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
    public GameObject player;

    public Button buttonPrefab;
    public RectTransform buttonParent;


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

        // Create buttons for all messages that have choices
        for (int i = 0; i < currentMessages.Length; i++) {
            Message messageToDisplay = currentMessages[i];
            if (messageToDisplay.choices.Length > 0) {
                // Create a button for each choice in the current message
                for (int j = 0; j < messageToDisplay.choices.Length; j++) {
                    Button button = Instantiate(buttonPrefab, buttonParent);
                    button.GetComponentInChildren<TextMeshProUGUI>().text = messageToDisplay.choices[j];
                    int index = j; // Capture the index in a local variable
                    button.onClick.AddListener(() => {
                        MakeChoice(index);
                    });
                }
            }
        }

        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();

        // disable player movement
        player.GetComponent<PlayerController>().enabled = false;

        // set animation to idle
        player.GetComponent<Animator>().SetBool("isMoving", false);
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
        // Animate the buttons out before destroying them
        foreach (Transform child in buttonParent) {
            LeanTween.scale(child.gameObject, Vector3.zero, 0.5f).setEaseInOutExpo().setOnComplete(() => {
                Destroy(child.gameObject);
            });
        }

        activeMessage++;
        if (activeMessage < currentMessages.Length) {
            Message messageToDisplay = currentMessages[activeMessage];
            if (messageToDisplay.choices.Length > 0) {
                // Start a coroutine to create the buttons after a delay
                StartCoroutine(CreateButtons(messageToDisplay));
            } else {
                DisplayMessage();
            }
        } else {
            Debug.Log("Conversation Ended");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;

            // enable player movement
            player.GetComponent<PlayerController>().enabled = true;
        }
    }

    IEnumerator CreateButtons(Message messageToDisplay) {
        yield return new WaitForSeconds(0.5f); // Delay for 0.5 seconds

        // Create a button for each choice in the current message
        for (int i = 0; i < messageToDisplay.choices.Length; i++) {
            Button button = Instantiate(buttonPrefab, buttonParent);
            button.GetComponentInChildren<TextMeshProUGUI>().text = messageToDisplay.choices[i];
            int index = i; // Capture the index in a local variable
            button.onClick.AddListener(() => {
                MakeChoice(index);
            });

            // Animate the button in
            LeanTween.scale(button.gameObject, Vector3.one, 0.5f).setEaseInOutExpo();
        }

        DisplayMessage();
    }

    void MakeChoice(int choiceIndex) {
        // Display the message corresponding to the chosen option
        StopCoroutine("CreateButtons");
        activeMessage = currentMessages[activeMessage].nextMessageIndices[choiceIndex];
        foreach (Transform child in buttonParent) {
            LeanTween.scale(child.gameObject, Vector3.zero, 0.5f).setEaseInOutExpo().setOnComplete(() => {
                Destroy(child.gameObject);
            });
        }

        
        // Display the next message
        NextMessage();
    }

    void AnimateTextColor() {
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
            if (currentMessages[activeMessage].choices.Length > 0) {
                // Don't do anything if the current message has choices
                return;
            }
            NextMessage();
        }
    }
}
