using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class RotationSpeed : IComponent { public float Value; }
    [Game] public class Direction : IComponent { public Vector3 Value; }
    [Game] public class Moving : IComponent { }
    [Game] public class MovementAvailable : IComponent { }
    
    [Game] public class PhysicalMover : IComponent { }
    [Game] public class InitPositionPhysicalMover : IComponent { }
    
    [Game] public class WayPointsMove : IComponent { public Vector3[] Value; }
    [Game] public class WayPointsMoveIndex : IComponent { public int Value; }
    [Game] public class ArrivalThreshold : IComponent { public float Value; }
}