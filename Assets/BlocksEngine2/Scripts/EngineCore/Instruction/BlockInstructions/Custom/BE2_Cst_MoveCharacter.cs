using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_Cst_MoveCharacter : BE2_InstructionBase, I_BE2_Instruction
{
    // ► Refer to the documentation for more on the variables and methods

    // ### Execution Methods ###

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)

    // I have now 2 inputs, one for the direction and one for the speed
    // get the inputs from the first section
    I_BE2_BlockSectionHeaderInput _input0;
    I_BE2_BlockSectionHeaderInput _input1;

    public new void Function()
    {
        // --- use Section0Inputs[inputIndex] to get the Block inputs from the first section (index 0).
        // --- Optionally, use GetSectionInputs(sectionIndex)[inputIndex] to get inputs from a different section
        // --- the input values can be retrieved as .StringValue, .FloatValue or .InputValues 
        // Section0Inputs[inputIndex];

        // switch statement to check which input the user picked
        // if the input0 is at "X" axis. then move the character on the X axis with the given speed which is the _input1
        // if the input0 is at "Y" axis. then move the character on the Y axis with the given speed which is the _input1
        // Using TargetObject Transform

        // store the first input from the first section in the variable _input0
        _input0 = Section0Inputs[0];
        // store the second input from the first section in the variable _input1
        _input1 = Section0Inputs[1];

        // I want the movement to increment the current position of the character by the given speed

        // I also need to multiply it by Time.deltaTime to make the movement smooth

        // limit the _input1 to only a maximum of 5 so that if the player inputs higher than 5. it will be capped at 5
        // same goes in the -5 to 5 range
        
        float speed = Mathf.Clamp(_input1.FloatValue, -5, 5);
    


        switch (_input0.StringValue)
        {
            case "X":
                TargetObject.Transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                break;
            case "Y":
                TargetObject.Transform.position += new Vector3(0, speed * Time.deltaTime, 0);
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
