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
    void Start()
    {
        blockMode.SetActive(false);
        popUp.SetActive(false);
        popUpText.SetActive(false);
        popUpButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideModeButtons() {
        modeButtons.SetActive(false);
        blockMode.SetActive(true);
    }

    public void ShowModeButtons() {
        modeButtons.SetActive(true);
        blockMode.SetActive(false);
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
