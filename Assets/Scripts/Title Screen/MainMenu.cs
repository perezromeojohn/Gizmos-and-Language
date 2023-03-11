using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        // add a dotween delay before the buttons are scaled

        buttons[4].transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).SetDelay(0.3f);
        buttons[3].transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).SetDelay(0.3f);
        buttons[2].transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).SetDelay(0.6f);
        buttons[1].transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).SetDelay(0.9f);
        buttons[0].transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).SetDelay(1.2f);
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
