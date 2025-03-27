using Entitas;

namespace Code.Gameplay.Features.Camera
{
    [Game] public class MainCamera : IComponent { }
    [Game] public class CameraUnity : IComponent { public UnityEngine.Camera Value; }
}