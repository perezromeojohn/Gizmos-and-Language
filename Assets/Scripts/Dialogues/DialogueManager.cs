using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{

    private static DialogueManager instance;

    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.01f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private Animator portrait;
    [SerializeField] private GameObject continuePrompt;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choiceTexts;

    private Story currentStory;
    public  bool dialogueIsPlaying { get; private set; }
    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
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

        if (canContinueToNextLine && Input.GetKeyDown(KeyCode.F) && currentStory.currentChoices.Count == 0) {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        speakerName.text = "";
        portrait.Play("default");

        ContinueStory();
    }

    private void ExitDialogueMode() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory() {
        if (currentStory.canContinue) {
            // dialogueText.text = currentStory.Continue();
            if (displayLineCoroutine != null) {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            // handle tags
            HandleTags(currentStory.currentTags);
        } else {
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line) {
        dialogueText.text = "";

        continuePrompt.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;
        
        bool isAddingTextTag = false;

        foreach (char c in line.ToCharArray()) {

            if (Input.GetKeyDown(KeyCode.F)) {
                dialogueText.text = line;
                break;
            }
        
            if (c == '<' && isAddingTextTag) {
                isAddingTextTag = true;
                dialogueText.text += c;
                if (c == '>') {
                    isAddingTextTag = false;
                }
            } else {
                dialogueText.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        canContinueToNextLine = true;
        DisplayChoices();

        continuePrompt.SetActive(true);
    }

    private void HandleTags(List<string> currentTags) {
        foreach (string tag in currentTags) {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2) {
                Debug.LogError("Tag is not in the correct format. Tag: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey) {
                case SPEAKER_TAG:
                    speakerName.text = tagValue;
                    break;
                case PORTRAIT_TAG:  
                    portrait.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled " + tag);
                    break;
            }
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

    private void HideChoices() {
        foreach (GameObject choice in choices) {
            choice.SetActive(false);
        }
    }

    public void ChooseChoice(int choiceIndex) {

        if (canContinueToNextLine) {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }
}
