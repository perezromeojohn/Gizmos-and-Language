using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BE2_Ins_WhenJoystickKeyPressed : BE2_InstructionBase, I_BE2_Instruction
{
    Dropdown _dropdown;
    BE2_VirtualJoystick _virtualJoystick;

    //protected override void OnAwake()
    //{
    //     
    //}

    protected override void OnStart()
    {
        _dropdown = GetSectionInputs(0)[0].Transform.GetComponent<Dropdown>();
        _virtualJoystick = BE2_VirtualJoystick.instance;

        //PopulateDropdown();
        //_dropdown.value = _dropdown.options.FindIndex(option => option.text == "A");
        //ParseKeyCode();
        //_dropdown.onValueChanged.AddListener(delegate { ParseKeyCode(); });
    }

    //void PopulateDropdown()
    //{
    //    _dropdown.ClearOptions();
    //    string[] keys = System.Enum.GetNames(typeof(KeyCode));
    //    foreach (string key in keys)
    //    {
    //        _dropdown.options.Add(new Dropdown.OptionData(key));
    //    }
    //    _dropdown.RefreshShownValue();
    //}

    void Update()
    {
        if (_virtualJoystick.keys[_dropdown.value].isPressed)
        {
            BlocksStack.IsActive = true;
        }
    }

    //KeyCode _key;
    //void ParseKeyCode()
    //{
    //    KeyCode key = KeyCode.A;
    //    try
    //    {
    //        key = (KeyCode)System.Enum.Parse(typeof(KeyCode), GetSectionInputs(0)[0].StringValue);
    //    }
    //    catch { }
    //    _key = key;
    //}

    public new void Function()
    {
        ExecuteSection(0);
    }
}
