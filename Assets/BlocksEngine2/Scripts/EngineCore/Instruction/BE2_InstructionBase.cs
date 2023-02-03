using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;

namespace MG_BlocksEngine2.Block.Instruction
{
    public class BE2_InstructionBase : MonoBehaviour, I_BE2_InstructionBase
    {
        I_BE2_BlockLayout _blockLayout;
        I_BE2_BlockSection[] _sectionsList;
        I_BE2_BlockSectionHeader _section0header;
        int _lastLocation;

        public I_BE2_Instruction Instruction { get; set; }
        public I_BE2_Block Block { get; set; }
        public I_BE2_BlocksStack BlocksStack { get; set; }
        public I_BE2_TargetObject TargetObject { get; set; }
        public int[] LocationsArray { get; set; }
        protected virtual void OnAwake() { }
        protected virtual void OnStart() { }
        protected virtual void OnButtonPlay() { }
        protected virtual void OnButtonStop() { }
        public virtual void OnPrepareToPlay() { }
        public virtual void OnStackActive() { }

        void Awake()
        {
            InstructionBase = this;
            Instruction = GetComponent<I_BE2_Instruction>();
            Block = GetComponent<I_BE2_Block>();
            _blockLayout = GetComponent<I_BE2_BlockLayout>();

            if (Block.Type == BlockTypeEnum.trigger)
            {
                BlocksStack = GetComponent<I_BE2_BlocksStack>();
            }

            _section0header = transform.GetChild(0).GetChild(0).GetComponent<I_BE2_BlockSectionHeader>();
            _section0header.UpdateInputsArray();

            OnAwake();
        }

        void Start()
        {
            I_BE2_BlockSection[] tempSectionsArr = _blockLayout.SectionsArray;
            LocationsArray = new int[
                BE2_ArrayUtils.FindAll(ref tempSectionsArr, (x => x.Body != null)).Length + 1];

            _sectionsList = _blockLayout.SectionsArray;

            BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPlay, OnButtonPlay);
            BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnStop, OnButtonStop);
            BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, GetBlockStack);

            OnStart();
        }

        void OnDisable()
        {
            BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPlay, OnButtonPlay);
            BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnStop, OnButtonStop);
            BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, GetBlockStack);
        }

        // v2.7 - added method on the instruction to get the TargetObject (not null when block is placed in a ProgrammingEnv)
        public I_BE2_TargetObject GetTargetObject()
        {
            return GetComponentInParent<I_BE2_ProgrammingEnv>()?.TargetObject;
        }

        void GetBlockStack()
        {
            BlocksStack = GetComponentInParent<I_BE2_BlocksStack>();
            if (BlocksStack == null)
            {
                Block.SetShadowActive(false);
            }
            else if (BlocksStack.IsActive)
            {
                Block.SetShadowActive(true);
            }
        }

        public I_BE2_BlockSectionHeaderInput[] Section0Inputs
        {
            get
            {
                return _section0header?.InputsArray;
            }
        }

        public I_BE2_BlockSectionHeaderInput[] GetSectionInputs(int sectionIndex)
        {
            return _sectionsList[sectionIndex].Header.InputsArray;
        }

        public void PrepareToPlay()
        {
            _lastLocation = LocationsArray[LocationsArray.Length - 1];

            OnPrepareToPlay();
        }

        int _overflowLimit = 100;

        public void ExecuteSection(int sectionIndex)
        {
            if (BlocksStack.InstructionsArray.Length > LocationsArray[sectionIndex])
            {
                I_BE2_Instruction instruction = BlocksStack.InstructionsArray[LocationsArray[sectionIndex]];
                BlockTypeEnum type = instruction.InstructionBase.Block.Type;
                // v2.1 - Loops are now executed "in frame" instead of mandatorily "in update". Faster loop execution and nested loops without delay
                if (!instruction.ExecuteInUpdate && BlocksStack.OverflowGuard < _overflowLimit)
                {
                    BlocksStack.OverflowGuard++;
                    instruction.Function();
                }
                else
                {
                    BlocksStack.Pointer = LocationsArray[sectionIndex];
                }
            }
            else
            {
                BlocksStack.Pointer = LocationsArray[sectionIndex];
            }
        }

        public void ExecuteNextInstruction()
        {
            if (BlocksStack.InstructionsArray.Length > _lastLocation)
            {
                I_BE2_Instruction instruction = BlocksStack.InstructionsArray[_lastLocation];
                BlockTypeEnum type = instruction.InstructionBase.Block.Type;
                // v2.1 - Loops are now executed "in frame" instead of mandatorily "in update". Faster loop execution and nested loops without delay
                if (!instruction.ExecuteInUpdate && BlocksStack.OverflowGuard < _overflowLimit)
                {
                    BlocksStack.OverflowGuard++;
                    instruction.Function();
                }
                else
                {
                    BlocksStack.Pointer = _lastLocation;
                }
            }
            else
            {
                BlocksStack.Pointer = _lastLocation;
            }
        }

        // ### Instruction ###
        public I_BE2_InstructionBase InstructionBase { get; set; }
        public bool ExecuteInUpdate { get; }

        public string Operation() { return ""; }
        public void Function() { }
    }
}