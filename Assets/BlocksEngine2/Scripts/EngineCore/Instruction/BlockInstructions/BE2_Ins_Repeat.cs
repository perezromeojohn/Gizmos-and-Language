using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_Ins_Repeat : BE2_InstructionBase, I_BE2_Instruction
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
    int _counter = 0;
    float _value;

    protected override void OnButtonStop()
    {
        _counter = 0;
        //EndLoop = false;
    }

    public override void OnStackActive()
    {
        _counter = 0;
        //EndLoop = false;
    }

    public new void Function()
    {
        _input0 = Section0Inputs[0];
        _value = _input0.FloatValue;

        if (_counter != _value)
        {
            _counter++;
            ExecuteSection(0);
        }
        else
        {
            //EndLoop = true;
            _counter = 0;
            ExecuteNextInstruction();
        }
    }
}
