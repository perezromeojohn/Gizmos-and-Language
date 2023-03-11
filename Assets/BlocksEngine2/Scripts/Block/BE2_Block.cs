using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BE2_Block : MonoBehaviour, I_BE2_Block
{
    BE2_DragDropManager _dragDropManager;

    [SerializeField]
    BlockTypeEnum _type;
    public BlockTypeEnum Type { get => _type; set => _type = value; }
    Transform _transform;
    public Transform Transform => _transform ? _transform : transform;
    public I_BE2_BlockLayout Layout { get; set; }
    public I_BE2_Instruction Instruction { get; set; }
    public I_BE2_BlockSection ParentSection { get; set; }
    public I_BE2_Drag Drag { get; set; }

    void OnValidate()
    {
        _transform = transform;
        Image outerImage = Transform.GetChild(Transform.childCount - 1).GetComponent<Image>();
        if (outerImage) outerImage.raycastTarget = false;

        Awake();
    }

    void Awake()
    {
        _transform = transform;
        Layout = GetComponent<I_BE2_BlockLayout>();
        Instruction = GetComponent<I_BE2_Instruction>();

        _dragDropManager = FindObjectOfType<BE2_DragDropManager>();
        Drag = GetComponent<I_BE2_Drag>();
    }

    void Start()
    {
        AddSpotsToManager();
        // v2.1 - bugfix: fixed detection of spots between child blocks before first block is dropped 
        GetParentSection();
        BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, GetParentSection);
    }

    void OnDisable()
    {
        BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, GetParentSection);
    }

    void GetParentSection()
    {
        ParentSection = GetComponentInParent<I_BE2_BlockSection>();
    }

    //void Update()
    //{
    //
    //}

    void OnDestroy()
    {
        RemoveSpotsFromManager();
    }

    public void AddSpotsToManager()
    {
        foreach (I_BE2_BlockSection section in Layout.SectionsArray)
        {
            if (section.Body != null && section.Body.Spot != null)
                _dragDropManager.AddToSpotsList(section.Body.Spot);

            foreach (I_BE2_BlockSectionHeaderInput input in section.Header.InputsArray)
            {
                _dragDropManager.AddToSpotsList(input.Spot);
            }

            BE2_SpotOuterArea outerSpot = Transform.GetChild(Transform.childCount - 1).GetComponent<BE2_SpotOuterArea>();
            if (outerSpot)
                _dragDropManager.AddToSpotsList(outerSpot);
        }
    }

    void RemoveSpotsFromManager()
    {
        foreach (I_BE2_BlockSection section in Layout.SectionsArray)
        {
            if (section.Body != null && section.Body.Spot != null)
                _dragDropManager.RemoveFromSpotsList(section.Body.Spot);

            foreach (I_BE2_BlockSectionHeaderInput input in section.Header.InputsArray)
            {
                _dragDropManager.RemoveFromSpotsList(input.Spot);
            }

            BE2_SpotOuterArea outerSpot = Transform.GetChild(Transform.childCount - 1).GetComponent<BE2_SpotOuterArea>();
            if (outerSpot)
                _dragDropManager.RemoveFromSpotsList(outerSpot);
        }
    }

    public void SetShadowActive(bool value)
    {
        if (Type != BlockTypeEnum.operation)
        {
            if (value)
            {
                foreach (I_BE2_BlockSection section in Layout.SectionsArray)
                {
                    if (section.Header != null)
                    {
                        section.Header.Shadow.enabled = true;
                    }
                    if (section.Body != null)
                    {
                        section.Body.Shadow.enabled = true;
                    }
                }
            }
            else
            {
                foreach (I_BE2_BlockSection section in Layout.SectionsArray)
                {
                    if (section.Header != null)
                    {
                        section.Header.Shadow.enabled = false;
                    }
                    if (section.Body != null)
                    {
                        section.Body.Shadow.enabled = false;
                    }
                }
            }
        }
    }
}
