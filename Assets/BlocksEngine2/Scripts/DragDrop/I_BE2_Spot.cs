using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_BE2_Spot
{
    Transform Transform { get; }
    Vector2 DropPosition { get; }
    I_BE2_Block Block { get; }
}
