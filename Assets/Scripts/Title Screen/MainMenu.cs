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

    public GameObject exitNoticeDim;
    public GameObject exitNotice;

    public GameObject mainColumn;
    public GameObject settingsColumn;

    void Awake() {
        // set alpha of the image gameTitle to 0

    }
    // Start is called before the first frame update
    void Start()
    {
        // set the exitNoticeDim image opacity to 0
        exitNoticeDim.GetComponent<Image>().DOFade(0, 0);
        exitNoticeDim.SetActive(false);
        // set the exitNotice scale to 0 and active to false
        exitNotice.transform.localScale = Vector3.zero;
        exitNotice.SetActive(false);
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

    public void exitPrompt() {
        // set the exitNoticeDim to active and the image faed to .7 within .5 seconds
        exitNoticeDim.SetActive(true);
        exitNoticeDim.GetComponent<Image>().DOFade(0.7f, 0.5f).SetEase(Ease.InOutExpo);

        // set the exitNotice to active and scale to 1 within .5 seconds
        exitNotice.SetActive(true);
        exitNotice.transform.DOScale(1, 0.5f).SetEase(Ease.InOutExpo);
    }

    public void returnToMenu() {
        // ser the exitNoticeDim the image fade to 0 and then on complete set the exitNoticeDim to inactive
        exitNoticeDim.GetComponent<Image>().DOFade(0, 0.5f).SetEase(Ease.InOutExpo).OnComplete(() => exitNoticeDim.SetActive(false));

        // set the exitNotice to scale to 0 and then on complete set the exitNotice to inactive
        exitNotice.transform.DOScale(0, 0.5f).SetEase(Ease.InOutExpo).OnComplete(() => exitNotice.SetActive(false));
    }

    public void exitApplication() {
        Debug.Log("Application Quit");
        Application.Quit();
    }

    // make me a link director to this page https://www.freeprivacypolicy.com/live/ac421c71-1c3d-44af-ac64-0fc3cda56b63
    public void privacyPolicy() {
        Application.OpenURL("https://www.freeprivacypolicy.com/live/ac421c71-1c3d-44af-ac64-0fc3cda56b63");
    }

    // hide main column, show settings column
    public void settings() {
        mainColumn.SetActive(false);
        settingsColumn.SetActive(true);
    }

    // hide settings column, show main column
    public void menu() {
        settingsColumn.SetActive(false);
        mainColumn.SetActive(true);
    }
}
