using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_Op_Xnor : BE2_InstructionBase, I_BE2_Instruction
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
    string _vs0;
    string _vs1;

    public new string Operation()
    {
        _input0 = Section0Inputs[0];
        _input1 = Section0Inputs[1];
        _vs0 = _input0.StringValue;
        _vs1 = _input1.StringValue;

        return !((_vs0 == "1" || _vs0 == "true") ^ (_vs1 == "1" || _vs1 == "true"))
        ? "1" : "0";
    }
}
