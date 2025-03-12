using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input
{
    [Input] public class Input : IComponent { }
    [Input] public class AxisInput : IComponent { public Vector2 Value; }
    [Input] public class CameraZoomInput : IComponent { public float Value; }
    [Input] public class AttackInput : IComponent { }
}