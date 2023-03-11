using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class BE2_BlockSectionHeader_Dropdown : MonoBehaviour, I_BE2_BlockSectionHeaderItem, I_BE2_BlockSectionHeaderInput
{
    Dropdown _dropdown;
    RectTransform _rectTransform;

    public Transform Transform => transform;
    public Vector2 Size => _rectTransform ? _rectTransform.sizeDelta : GetComponent<RectTransform>().sizeDelta;
    public I_BE2_Spot Spot { get; set; }
    public float FloatValue { get; set; }
    public string StringValue { get; set; }
    public BE2_InputValues InputValues { get; set; }

    void OnValidate()
    {
        Awake();
    }

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _dropdown = GetComponent<Dropdown>();
        Spot = GetComponent<I_BE2_Spot>();
    }

    void OnEnable()
    {
        UpdateValues();
        _dropdown.onValueChanged.AddListener(delegate { UpdateValues(); });
    }

    void OnDisable()
    {
        _dropdown.onValueChanged.RemoveAllListeners();
    }

    void Start()
    {
        GetComponent<BE2_DropdownDynamicResize>().Resize();
        UpdateValues();
    }

    //void Update()
    //{
    //
    //}

    public void UpdateValues()
    {
        bool isText;
        if (_dropdown.options.Count > 0)
        {
            StringValue = _dropdown.options[_dropdown.value].text;
        }
        else
        {
            StringValue = "";
        }

        float floatValue = 0;
        try
        {
            floatValue = float.Parse(StringValue, CultureInfo.InvariantCulture);
            isText = false;
        }
        catch
        {
            isText = true;
        }
        FloatValue = floatValue;

        InputValues = new BE2_InputValues(StringValue, FloatValue, isText);

        //I_BE2_Instruction parentInstructionNotOper = GetParentInstructionNotOperation(transform.parent);
        //if (parentInstructionNotOper != null)
        //{
        //    parentInstructionNotOper.InstructionBase.FetchInputs();
        //}
    }

    //I_BE2_Instruction GetParentInstructionNotOperation(Transform parent)
    //{
    //    I_BE2_Instruction parentInstruction = null;
    //
    //    I_BE2_Instruction ins = parent.GetComponentInParent<I_BE2_Instruction>();
    //    if (ins != null && ins.InstructionBase != null)
    //    {
    //        if (ins.InstructionBase.Block.Type != BlockTypeEnum.operation)
    //        {
    //            parentInstruction = ins;
    //        }
    //        else
    //        {
    //            parentInstruction = GetParentInstructionNotOperation(ins.InstructionBase.Block.Transform.parent);
    //        }
    //    }
    //
    //    return parentInstruction;
    //}
}
