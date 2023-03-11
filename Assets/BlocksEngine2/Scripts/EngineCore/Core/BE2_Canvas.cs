using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// v2.6 - added BE2_Canvas component, used to identify all the BE2 key canvas
public class BE2_Canvas : MonoBehaviour
{
    Canvas _canvas;
    public Canvas Canvas
    {
        get
        {
            if (!_canvas)
            {
                _canvas = GetComponent<Canvas>();
            }
            return _canvas;
        }
    }
}
