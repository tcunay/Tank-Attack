using CodeBase.Gameplay.Input.Generated;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Gameplay.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Vertical = "Vertical";
        protected const string Horizontal = "Horizontal";
        private const string SimpleInputZoom = "SimpleInputZoom";
        private const string MouseScrollWheel = "Mouse ScrollWheel";
        
        private const string FireButtonKey = "Fire";

        protected PlayerInputActions _playerInput;

        protected InputService()
        {
            _playerInput = new PlayerInputActions();
            _playerInput.Player.Enable();
        }
        
        public virtual Vector2 Axis => SimpleInputAxis();

        public virtual bool IsAttackButton() => SimpleInput.GetButtonUp(FireButtonKey);
        
        public float CameraZoomAxis()
        {
            return SimpleInputZoomAxis();
        }
        
        protected static Vector2 SimpleInputAxis() => 
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

        private float SimpleInputZoomAxis() => 
            SimpleInput.GetAxis(SimpleInputZoom);
    }
}