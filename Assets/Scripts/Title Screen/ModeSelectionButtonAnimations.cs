using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ModeSelectionButtonAnimations : MonoBehaviour
{
    [SerializeField] private GameObject[] modeSelectionButtons;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject button in modeSelectionButtons) {
            // set scale to 0
            button.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        }

        // scale them one at a time using sequence append
        Sequence sequence = DOTween.Sequence();

        // add a delay to the sequence
        sequence.AppendInterval(0.2f);

        // for loop to iterate through the buttons array
        for (int i = 0; i < modeSelectionButtons.Length; i++) {
            sequence.Append(modeSelectionButtons[i].transform.DOScale(1, 0.4f).SetEase(Ease.OutBack));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
