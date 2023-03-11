using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BE2_UI_PanelCancel : MonoBehaviour, IPointerDownHandler
{
    //void Awake()
    //{
    //
    //}
    //
    //void Start()
    //{
    //
    //}
    //
    //void Update()
    //{
    //
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        BE2_UI_ContextMenuManager.instance.CloseContextMenu();
    }
}
