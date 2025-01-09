using UnityEngine;

namespace CodeBase.Gameplay.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
        public override float CameraZoomAxis => 0;
    }
}