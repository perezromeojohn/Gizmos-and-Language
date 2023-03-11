using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_Op_Random : BE2_InstructionBase, I_BE2_Instruction
{
    //protected override void OnAwake()
    //{
    //
    //}

    //protected override void OnStart()
    //{
    //    
    //}

    I_BE2_BlockSectionHeaderInput _input0;
    I_BE2_BlockSectionHeaderInput _input1;
    BE2_InputValues _v0;
    BE2_InputValues _v1;

    public new string Operation()
    {
        _input0 = Section0Inputs[0];
        _input1 = Section0Inputs[1];
        _v0 = _input0.InputValues;
        _v1 = _input1.InputValues;

        if (_v0.isText || _v1.isText)
        {
            return "0";
        }
        else
        {
            // <!> you can use this if you want to differentiate float or int ranges
            /*
            if(_input0.StringValue.Contains(".")||_input1.StringValue.Contains("."))
            {
                return Random.Range(_input0.FloatValue, _input1.FloatValue).ToString();
            }
            else
            {
                return Random.Range((int)_input0.FloatValue, (int)_input1.FloatValue).ToString();
            }
            */

            return Random.Range(_v0.floatValue, _v1.floatValue).ToString();
        }
    }
}
