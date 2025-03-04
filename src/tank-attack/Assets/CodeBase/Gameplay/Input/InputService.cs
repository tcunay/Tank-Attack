using CodeBase.Gameplay.Input.Generated;
using UnityEngine;

namespace CodeBase.Gameplay.Input
{
    public class InputService : IInputService
    {
        private readonly PlayerInputActions _playerInput;
        
        public float CameraZoomAxis { get; set; }

        protected InputService()
        {
            _playerInput = new PlayerInputActions();
            _playerInput.Player.Enable();
        }
        
        public virtual Vector2 Axis => SimpleInputAxis();

        public virtual bool IsAttackButton() => _playerInput.Player.Attack.triggered;
        
        private Vector2 SimpleInputAxis() => _playerInput.Player.Move.ReadValue<Vector2>();
    }
}