using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TestStuff : MonoBehaviour
{
    [SerializeField] private Transform stuff;
    // Start is called before the first frame update
    void Start()
    {
        stuff.DOScale(0, 10f).SetEase(Ease.OutBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
