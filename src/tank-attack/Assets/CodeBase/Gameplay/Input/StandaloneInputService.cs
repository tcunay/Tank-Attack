using UnityEngine;

namespace CodeBase.Gameplay.Input
{
    public class StandaloneInputService : InputService
    {
        private const string MouseScrollWheel = "Mouse ScrollWheel";

        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = SimpleInputAxis();

                if (axis == Vector2.zero)
                {
                    axis = UnityAxis();
                }
                
                return axis;
            }
        }
        
        public override float CameraZoomAxis
        {
            get
            {
                float axis = SimpleInputZoomAxis();

                if (axis == 0)
                {
                    axis = UnityZoomAxis();
                }
                
                return axis;
            }
        }

        public override bool IsAttackButton()
        {
            return base.IsAttackButton() || UnityEngine.Input.GetKeyDown(KeyCode.Space);
        }

        private static Vector2 UnityAxis() => 
            new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
        
        private float UnityZoomAxis() => 
            UnityEngine.Input.GetAxis(MouseScrollWheel) * 30;
    }
}