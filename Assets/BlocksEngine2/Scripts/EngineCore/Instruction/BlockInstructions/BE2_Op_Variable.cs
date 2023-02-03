using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Environment;

public class BE2_Op_Variable : BE2_InstructionBase, I_BE2_Instruction
{
    //protected override void OnAwake()
    //{
    //
    //}
    //

    protected override void OnStart()
    {
        _variablesManager = BE2_VariablesManager.instance;
    }

    BE2_VariablesManager _variablesManager;
    I_BE2_BlockSectionHeaderInput _input0;

    public new string Operation()
    {
        _input0 = Section0Inputs[0];
        return _variablesManager.GetVariableStringValue(_input0.StringValue);
    }
}
