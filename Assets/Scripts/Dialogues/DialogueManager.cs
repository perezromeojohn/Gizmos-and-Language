using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{

    private static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choiceTexts;

    private Story currentStory;
    public  bool dialogueIsPlaying { get; private set; }
    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of DialogueManager found!");
        }
        instance = this;
    }

    public static DialogueManager GetInstance() {
        return instance;
    }

    private void Start() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choiceTexts = new TextMeshProUGUI[choices.Length];
        int i = 0;
        foreach (GameObject choice in choices) {
            choiceTexts[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }
    }

    private void Update() {
        if (!dialogueIsPlaying) return;

        if (Input.GetKeyDown(KeyCode.F)) {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory() {
        if (currentStory.canContinue) {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        } else {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices() {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > 0) {
            Debug.LogError("More choices were given the UI can support. Number of Choices" + currentChoices.Count);
        }

        int i = 0;
        foreach (Choice choice in currentChoices) {
            choices[i].gameObject.SetActive(true);
            choiceTexts[i].text = choice.text;
            i++;
        }
        
        for (int j = i; j < choices.Length; j++) {
            choices[j].gameObject.SetActive(false);
        }
    }

    public void ChooseChoice(int choiceIndex) {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
