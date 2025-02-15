using UnityEngine;

namespace CodeBase.Gameplay.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Vertical = "Vertical";
        protected const string Horizontal = "Horizontal";
        private const string SimpleInputZoom = "SimpleInputZoom";
        private const string MouseScrollWheel = "Mouse ScrollWheel";
        
        private const string FireButtonKey = "Fire";

        public abstract Vector2 Axis { get; }

        public virtual bool IsAttackButton() => SimpleInput.GetButtonUp(FireButtonKey);
        
        public float CameraZoomAxis()
        {
            float axis = SimpleInputZoomAxis();

            if (axis == 0)
            {
                axis = UnityZoomAxis();
            }
                
            return axis;
        }

        protected static Vector2 SimpleInputAxis() => 
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

        private float SimpleInputZoomAxis() => 
            SimpleInput.GetAxis(SimpleInputZoom);
        
        private float UnityZoomAxis() => 
            UnityEngine.Input.GetAxis(MouseScrollWheel) * 30;
        
        

    }
}