﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_BlocksStack : MonoBehaviour, I_BE2_BlocksStack
{
    int _arrayLength;
    bool _isActive = false;

    public int Pointer { get; set; }
    public I_BE2_Instruction[] InstructionsArray { get; set; }
    public I_BE2_TargetObject TargetObject { get; set; }
    public I_BE2_Instruction TriggerInstruction { get; set; }
    public bool markToAdd;
    public bool MarkToAdd { get => markToAdd; set => markToAdd = value; }
    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (!IsActive && value)
            {
                int instructionsCount = InstructionsArray.Length;
                for (int i = 0; i < instructionsCount; i++)
                {
                    InstructionsArray[i].InstructionBase.OnStackActive();
                }

                // activate all shadows
                foreach (I_BE2_Instruction instruction in InstructionsArray)
                {
                    instruction.InstructionBase.Block.SetShadowActive(true);
                }
            }
            else if (IsActive && !value)
            {
                // deactivate all shadows
                foreach (I_BE2_Instruction instruction in InstructionsArray)
                {
                    instruction.InstructionBase.Block.SetShadowActive(false);
                }
            }

            _isActive = value;
        }
    }

    void Awake()
    {
        MarkToAdd = false;
        TriggerInstruction = GetComponent<I_BE2_Instruction>();
        IsActive = false;
    }

    void Start()
    {
        PopulateStack();
        BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, PopulateStack);
        BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnStop, StopStack);
    }

    void OnDisable()
    {
        BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, PopulateStack);
        BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnStop, StopStack);
        BE2_ExecutionManager.Instance.RemoveFromBlocksStackList(this);
    }

    void StopStack()
    {
        Pointer = 0;
        IsActive = false;
    }

    //void Update()
    //{
    //
    //}

    public int OverflowGuard { get; set; }
    
    // v2.4 - Execute method of Blocks Stack refactored 
    public void Execute()
    {
        if (IsActive && _arrayLength > Pointer)
        {
            if (Pointer == 0)
            {
                I_BE2_Block firstBlock = TriggerInstruction.InstructionBase.Block;
                BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnStackExecutionStart, firstBlock);
            }

            InstructionsArray[Pointer].Function();
            OverflowGuard = 0;
        }

        if (InstructionsArray != null && Pointer == InstructionsArray.Length && InstructionsArray.Length > 0)
        {
            I_BE2_Block lastBlock = InstructionsArray[InstructionsArray.Length - 1].InstructionBase.Block;
            BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnStackExecutionEnd, lastBlock);

            Pointer = 0;
            IsActive = false;
        }
    }

    public void PopulateStack()
    {
        InstructionsArray = new I_BE2_Instruction[0];
        PopulateStackRecursive(TriggerInstruction.InstructionBase.Block);
        _arrayLength = InstructionsArray.Length;
    }

    void PopulateStackRecursive(I_BE2_Block parentBlock)
    {
        int locationsCount = 0;

        I_BE2_Instruction parentInstruction = parentBlock.Instruction;
        I_BE2_InstructionBase parentInstructionBase = parentInstruction as I_BE2_InstructionBase;
        parentInstructionBase.TargetObject = TargetObject;
        parentInstructionBase.BlocksStack = this;

        // ---> add to layout number of bodies and use this number to create the locations array
        I_BE2_BlockSection[] tempSectionsArr = parentInstructionBase.Block.Layout.SectionsArray;
        parentInstructionBase.LocationsArray = new int[
            BE2_ArrayUtils.FindAll(ref tempSectionsArr, (x => x.Body != null)).Length + 1];

        InstructionsArray = BE2_ArrayUtils.AddReturn(InstructionsArray, parentInstruction);

        int sectionsCount = parentBlock.Layout.SectionsArray.Length;
        for (int i = 0; i < sectionsCount; i++)
        {
            I_BE2_BlockSection section = parentBlock.Layout.SectionsArray[i];
            if (section.Body != null)
            {

                if (parentBlock.Type != BlockTypeEnum.trigger)
                {
                    parentInstructionBase.LocationsArray[locationsCount] = InstructionsArray.Length;

                    locationsCount++;
                }
                else
                {
                    parentInstructionBase.LocationsArray[locationsCount] = 1;
                }

                section.Body.UpdateChildBlocksList();
                I_BE2_Block[] childBlocks = section.Body.ChildBlocksArray;

                int childBlocksCount = childBlocks.Length;
                for (int j = 0; j < childBlocksCount; j++)
                {
                    PopulateStackRecursive(childBlocks[j]);
                }

                if (parentBlock.Type != BlockTypeEnum.trigger)
                {
                    InstructionsArray = BE2_ArrayUtils.AddReturn(InstructionsArray, parentInstruction);
                }
            }
        }

        if (parentBlock.Type != BlockTypeEnum.trigger)
            parentInstructionBase.LocationsArray[locationsCount] = InstructionsArray.Length;

        parentInstructionBase.PrepareToPlay();
    }
}
