using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BE2_SerializableBlock
{
    public string blockName;
    public Vector3 position;
    public List<BE2_SerializableSection> sections;
    public bool isVariable;
    public string varName;

    public BE2_SerializableBlock()
    {
        sections = new List<BE2_SerializableSection>();
    }
}

[System.Serializable]
public class BE2_SerializableSection
{
    public List<BE2_SerializableBlock> childBlocks;
    public List<BE2_SerializableInput> inputs;

    public BE2_SerializableSection()
    {
        childBlocks = new List<BE2_SerializableBlock>();
        inputs = new List<BE2_SerializableInput>();
    }
}

[System.Serializable]
public class BE2_SerializableInput
{
    public bool isOperation;
    public string value;
    public BE2_SerializableBlock operation;
}
