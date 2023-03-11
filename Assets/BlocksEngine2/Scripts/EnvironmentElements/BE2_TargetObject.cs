using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_TargetObject : MonoBehaviour, I_BE2_TargetObject
{
    public Transform Transform => transform;
    public I_BE2_ProgrammingEnv ProgrammingEnv { get; set; }
}
