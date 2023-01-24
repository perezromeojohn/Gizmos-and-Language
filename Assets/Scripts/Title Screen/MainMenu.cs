using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject gameTitle;

    void Awake() {
        // set alpha of the image gameTitle to 0

    }
    // Start is called before the first frame update
    void Start()
    {
        // off set the image panel attached to the canvas in x direction 267 and then create a set on complete function
        // LeanTween.moveX(panel.gameObject, 80, 3f).setEaseOutQuint().setOnComplete(() => {
        //     // for (int i = 0; i < buttons.Length; i++) lean scale the buttons individually with a .5f delay
        //     for (int i = 0; i < buttons.Length; i++) {
        //         LeanTween.scale(buttons[i], new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutExpo).setDelay(0.3f + (i * 0.3f));
        //     }
        // });
        LeanTween.delayedCall(3f, () => {
            for (int i = 0; i < buttons.Length; i++) {
                LeanTween.scale(buttons[i], new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutExpo).setDelay(0.3f + (i * 0.3f));
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
