using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ModeSelectionScript : MonoBehaviour
{
    [SerializeField] private GameObject modeButtons;
    [SerializeField] private GameObject blockMode;
    // Start is called before the first frame update
    [SerializeField] private GameObject popUp;

    [SerializeField] private GameObject popUpText;
    [SerializeField] private GameObject popUpButton;

    [SerializeField] private GameObject[] modeSelectionButtons;
    void Start()
    {
        blockMode.SetActive(false);
        popUp.SetActive(false);
        popUpText.SetActive(false);
        popUpButton.SetActive(false);


        foreach (GameObject button in modeSelectionButtons) {
            // set scale to 0
            button.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        }

        // scale them one at a time using sequence append
        Sequence sequence = DOTween.Sequence();

        // for loop to iterate through the buttons array
        for (int i = 0; i < modeSelectionButtons.Length; i++) {
            sequence.Append(modeSelectionButtons[i].transform.DOScale(1, 0.4f).SetEase(Ease.OutBack));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideModeButtons() {
        // scale down the modeSelectionButtons at the same time to 0 then setoncomplete set the modeButtons to false
        Sequence sequence = DOTween.Sequence();
        for (int i = 0; i < modeSelectionButtons.Length; i++) {
            sequence.Append(modeSelectionButtons[i].transform.DOScale(0, 0.2f).SetEase(Ease.InBack));
        }
        sequence.OnComplete(ShowBlockMode);
    }

    public void ShowBlockMode() {
        modeButtons.SetActive(false);
        blockMode.SetActive(true);
    }

    public void ShowModeButtons() {
        blockMode.SetActive(false);
        modeButtons.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        for (int i = 0; i < modeSelectionButtons.Length; i++) {
            sequence.Append(modeSelectionButtons[i].transform.DOScale(1, 0.2f).SetEase(Ease.OutBack));
        }
    }

    public void PopUp() {
        popUp.SetActive(true);
        popUpText.SetActive(true);
        popUpButton.SetActive(true);

        // fade in the pop up image
        popUp.GetComponent<Image>().DOFade(0.8f, 0.5f).SetEase(Ease.InOutExpo);

        // fade in the TMPro text
        popUpText.GetComponent<TMPro.TextMeshProUGUI>().DOFade(1.0f, 0.5f).SetEase(Ease.InOutExpo);

        // scale up the pop up button
        popUpButton.transform.DOScale(1.0f, 0.5f).SetEase(Ease.InOutExpo);
    }
}
