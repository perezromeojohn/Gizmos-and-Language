using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_Cst_FlipSprite : BE2_InstructionBase, I_BE2_Instruction
{
    // ► Refer to the documentation for more on the variables and methods

    // ### Execution Methods ###

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)

    // so this script is handling the flip sprite block, which is a function block
    // it works as if the user picks the contents inside of the dropdown which is X and Y, it will flip the sprite on the X and Y axis
    // so the user can pick which axis to flip the sprite on
    
    // now get the inputs from the first section
    
    // code here
    I_BE2_BlockSectionHeaderInput _input0;
    public new void Function()
    {
        // --- use Section0Inputs[inputIndex] to get the Block inputs from the first section (index 0).

        // --- Optionally, use GetSectionInputs(sectionIndex)[inputIndex] to get inputs from a different section
        // --- the input values can be retrieved as .StringValue, .FloatValue or .InputValues 
        // Section0Inputs[inputIndex];

        // get the first input from the first section and store it in the variable _input0
        _input0 = Section0Inputs[0];
        

        // now make a switch statement to check which input the user picked
        // if the user picked X, then flip the sprite on the X axis
        // if the user picked Y, then flip the sprite on the Y axis
        // Using TargetObject Transform 

        switch (_input0.StringValue)
        {
            case "Y":
                TargetObject.Transform.Rotate(Vector3.right, 180);
                break;
            case "X":
                TargetObject.Transform.Rotate(Vector3.up, 180);
                break;
            default:
                break;
        }

        // ### Stack Pointer Calls ###
        
        // --- execute first block inside the indicated section, used to execute blocks inside this block (ex. if, if/else, repeat)
        //ExecuteSection(sectionIndex);
        
        // --- execute next block after this, used to finish the execution of this function
        ExecuteNextInstruction();
    }
}
