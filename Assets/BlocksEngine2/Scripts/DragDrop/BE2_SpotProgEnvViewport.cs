using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_SpotProgEnvViewport : MonoBehaviour, I_BE2_Spot
{
    BE2_DragDropManager _dragDropManager;

    public string Type => "programmingEnv";
    Transform _transform;
    public Transform Transform => _transform ? _transform : transform;
    public Vector2 DropPosition => Vector2.zero;
    public I_BE2_Block Block => null;

    void Awake()
    {
        _transform = transform;
        _dragDropManager = FindObjectOfType<BE2_DragDropManager>();
    }

    //void Start()
    //{
    //
    //}
    
    //void Update()
    //{
    //
    //}

    public void OnPointerUp()
    {
        Debug.Log("?");
        I_BE2_Drag drag = _dragDropManager.CurrentDrag;
        if (drag != null)
            drag.Transform.SetParent(transform.GetChild(0));
    }

    void OnEnable()
    {
        _dragDropManager.AddToSpotsList(this);
    }

    void OnDisable()
    {
        _dragDropManager.RemoveFromSpotsList(this);
    }
}
