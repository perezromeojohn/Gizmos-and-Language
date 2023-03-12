using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

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

        // DOTween the above commented out code
        // use the above code as a reference

        // fade in the image
        if (image != null) {
            image.DOFade(1, 1f).SetEase(Ease.InOutExpo).SetDelay(1f);
        }

        // fade in the text
        if (text != null) {
            text.DOFade(1, 1f).SetEase(Ease.InOutExpo).SetDelay(1f);
        }

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

        // DOTween the above commented out code
        // use the above code as a reference

        // fade out the image
        if (image != null) {
            image.DOFade(0, 1f).SetEase(Ease.InOutExpo).SetDelay(6f);
        }

        // fade out the text
        if (text != null) {
            text.DOFade(0, 1f).SetEase(Ease.InOutExpo).SetDelay(6f);
        }
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
