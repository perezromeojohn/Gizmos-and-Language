using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_Ins_RepeatForever : BE2_InstructionBase, I_BE2_Instruction
{
    //protected override void OnAwake()
    //{
    //
    //}

    //protected override void OnStart()
    //{
    //    
    //}

    public new void Function()
    {
        ExecuteSection(0);
    }
}
