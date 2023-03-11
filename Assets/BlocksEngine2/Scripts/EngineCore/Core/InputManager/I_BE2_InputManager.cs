using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_BE2_InputManager
{
    void OnUpdate();
    Vector3 ScreenPointerPosition { get; }
    Vector3 CanvasPointerPosition { get; }
}
