using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_BE2_BlocksStack
{
    I_BE2_TargetObject TargetObject { get; set; }

    /// <summary>
    /// Starts/stops the execution stack
    /// </summary>
    bool IsActive { get; set; }

    /// <summary>
    /// True forces the stack to be added in the block stack array for future execution. True for all the new stacks
    /// </summary>
    bool MarkToAdd { get; set; }

    /// <summary>
    /// Instructions count per cycle
    /// </summary>
    int OverflowGuard { get; set; }

    /// <summary>
    /// Index of the current stack instruction 
    /// </summary>
    int Pointer { get; set; }

    I_BE2_Instruction TriggerInstruction { get; }
    I_BE2_Instruction[] InstructionsArray { get; set; }

    void Execute();
    
    /// <summary>
    /// Prepares the stack for execution
    /// </summary>
    void PopulateStack();
}
