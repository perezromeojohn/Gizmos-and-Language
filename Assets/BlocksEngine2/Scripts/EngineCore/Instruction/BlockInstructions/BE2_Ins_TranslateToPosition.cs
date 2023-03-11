using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_Ins_TranslateToPosition : BE2_InstructionBase, I_BE2_Instruction
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
    I_BE2_BlockSectionHeaderInput _input2;

    public new void Function()
    {
        _input0 = Section0Inputs[0];
        _input1 = Section0Inputs[1];
        _input2 = Section0Inputs[2];

        TargetObject.Transform.position = new Vector3(_input0.FloatValue, _input1.FloatValue, _input2.FloatValue);
        ExecuteNextInstruction();
    }
}
