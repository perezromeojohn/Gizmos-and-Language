using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_BE2_Instruction
{
    I_BE2_InstructionBase InstructionBase { get; }

    /// <summary>
    /// Default value is false. Set true to force the Instruction to be called in the update method of the Execution Manager.
    /// This setting should be set true for blocks that contain a condition to finish, causing it to be called repeatedly,
    /// ex.: loop blocks, wait, lerp (block slide forward)
    /// </summary>
    bool ExecuteInUpdate { get; }

    /// <summary>
    /// Used to implement the logic of operation blocks
    /// </summary>
    string Operation();

    /// <summary>
    /// Used to implement the logic of trigger, simple, condition and loop blocks
    /// </summary>
    void Function();
}
