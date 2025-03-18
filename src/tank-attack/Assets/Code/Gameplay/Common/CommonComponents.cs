//using Code.Gameplay.Common.Visuals;
//using Code.Gameplay.Common.Visuals.StatusVisuals;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Gameplay.Common
{
    [Game, Meta] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class Rotation : IComponent { public Vector3 Value; }
    [Game] public class Damage : IComponent { public float Value; }
    //[Game] public class Active : IComponent { }
    
    [Game] public class TransformComponent : IComponent { public Transform Value; }
    [Game] public class RigidbodyComponent : IComponent { public Rigidbody Value; }


}