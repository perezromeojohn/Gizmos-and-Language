using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_SpotBlockBody : MonoBehaviour, I_BE2_Spot
{
    BE2_DragDropManager _dragDropManager;
    RectTransform _rectTransform;

    Transform _transform;
    public Transform Transform => _transform ? _transform : transform;
    public Vector2 DropPosition => _rectTransform.position;
    public I_BE2_Block Block { get; set; }

    void Awake()
    {
        _transform = transform;
        _dragDropManager = FindObjectOfType<BE2_DragDropManager>();
        _rectTransform = GetComponent<RectTransform>();
        Block = GetComponentInParent<I_BE2_Block>();
    }

    //void Start()
    //{
    //
    //}

    //void Update()
    //{
    //
    //}

    void OnEnable()
    {
        _dragDropManager.AddToSpotsList(this);
    }

    void OnDisable()
    {
        _dragDropManager.RemoveFromSpotsList(this);
    }
}
