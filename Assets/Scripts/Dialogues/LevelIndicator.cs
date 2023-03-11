using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelIndicator : MonoBehaviour
{
    // get the image game object and the text mesh pro game object serialized
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string levelName;

    void Start() {
        // set the image and text to alpha 0
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        // set the text color to alpha 0
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);

        // set the level name according to the text passed in the inspector
        text.text = levelName;

        // Fade in the image, bgImage, and text
        // LeanTween.delayedCall(1f, () => {
        //     if (image != null) {
        //         LeanTween.alpha(image.rectTransform, 1, 1f);
        //     }
        //     if (text != null) {
        //         LeanTween.value(0, 1, 1f).setOnUpdate((float alpha) => {
        //             text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        //         });
        //     }
        // });

        // Fade out the image, bgImage, and text after 3 seconds
        // LeanTween.delayedCall(6f, () => {

        //     // LeanTween.alpha(image.rectTransform, 0, 1f);
        //     // LeanTween.alpha(bgImage.rectTransform, 0, 1f);
        //     // LeanTween.value(1, 0, 1f).setOnUpdate((float alpha) => {
        //     //     text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        //     // });

        //     if (image != null) {
        //         LeanTween.alpha(image.rectTransform, 0, 1f);
        //     }
        //     if (text != null) {
        //         LeanTween.value(1, 0, 1f).setOnUpdate((float alpha) => {
        //             text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        //         });
        //     }
        // });
    }

    void Update() {
        // when the dialogue from the dialogue manager is active, fade out the image, bgImage, and text
        if (DialogueManager.GetInstance().dialogueIsPlaying) {
            // set the image, bgImage, and text to false
            image.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
        }

        if (!DialogueManager.GetInstance().dialogueIsPlaying) {
            // set the image, bgImage, and text to true
            image.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
        }
    }
}
