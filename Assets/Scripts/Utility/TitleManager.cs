using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class TitleManager : MonoBehaviour
{
    // get  my image UI
    [SerializeField] private GameObject titleImage;

    void Start()
    {
        // set false to active of my image UI
        titleImage.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // after 2 seconds, fade out the image using dotween
        if (Input.anyKey)
        {
            // do tween alpha of gameobject image ui to 0, setoncomplete set active to false
            titleImage.GetComponent<Image>().DOFade(0, 1f).OnComplete(() => titleImage.gameObject.SetActive(false));
        }
    }
}
