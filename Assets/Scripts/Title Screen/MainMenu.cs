using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject itchButton;
    public GameObject gameTitle;
    public GameObject imageHolder;
    public GameObject gameVersion;
    public GameObject developer;

    void Awake() {
        // set alpha of the image gameTitle to 0

    }
    // Start is called before the first frame update
    void Start()
    {
        // add a dotween delay before the buttons are scaled
        // above code works fine but it's not very DRY
        // can you use DOTween.Sequence() to avoid repeating the same code?
        // use for loop to iterate through the buttons array
        Sequence mySequence = DOTween.Sequence();

        // add a delay to the sequence
        mySequence.AppendInterval(0.5f);
        
        // imageHolder fade in append
        mySequence.Append(imageHolder.GetComponent<Image>().DOFade(0.5f, 0.5f).SetEase(Ease.InOutExpo));
        // for loop to iterate through the buttons array
        for (int i = 0; i < buttons.Length; i++) {
            mySequence.Append(buttons[i].transform.DOScale(1, 0.5f).SetEase(Ease.OutBack));
        }
        

        // logo image
        gameTitle.GetComponent<Image>().DOFade(1, 0.5f).SetEase(Ease.InOutExpo).SetDelay(0.5f);
        // scale itch button
        itchButton.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).SetDelay(0.7f);
        // fade in game version (it's a text mesh pro object)
        gameVersion.GetComponent<TMPro.TextMeshProUGUI>().DOFade(1, 0.5f).SetEase(Ease.InOutExpo).SetDelay(0.5f);
        // fade in developer
        developer.GetComponent<Image>().DOFade(1, 0.5f).SetEase(Ease.InOutExpo).SetDelay(0.5f);
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
