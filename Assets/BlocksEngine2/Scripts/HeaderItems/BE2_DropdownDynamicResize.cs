using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class BE2_DropdownDynamicResize : MonoBehaviour
{
    RectTransform _rectTransform;
    Dropdown _dropdown;
    float _minWidth = 70;
    float _offset = 35;

    // v2.2 - added optional max width to the dropdown input
    public float maxWidth = 0;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _dropdown = GetComponent<Dropdown>();
    }

    void Start()
    {
        Resize();
    }

    //#if UNITY_EDITOR
    //    void Update()
    //    {
    //        if (!EditorApplication.isPlaying)
    //        {
    //            Resize();
    //        }
    //    }
    //#endif

    void OnEnable()
    {
        _dropdown.onValueChanged.AddListener(delegate { Resize(); });
    }

    void OnDisable()
    {
        _dropdown.onValueChanged.RemoveAllListeners();
    }

    public void Resize()
    {
        if (_dropdown)
        {
            float width = _offset + _dropdown.captionText.preferredWidth;
            if (width < _minWidth)
                width = _minWidth;

            if (maxWidth > 0 && width > maxWidth)
                width = maxWidth;

            _rectTransform.sizeDelta = new Vector2(width, _rectTransform.sizeDelta.y);
        }
    }
}
