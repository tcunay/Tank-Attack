using CodeBase.Gameplay.Input.Generated;
using UnityEngine;

namespace CodeBase.Gameplay.Input
{
    public class InputService : IInputService
    {
        private readonly PlayerInputActions _playerInput;
        
        protected InputService()
        {
            _playerInput = new PlayerInputActions();
            _playerInput.Player.Enable();
        }
        
        public float CameraZoomAxis { get; set; }
        
        public virtual Vector2 Axis => _playerInput.Player.Move.ReadValue<Vector2>();

        public virtual bool IsAttackButton() => _playerInput.Player.Attack.triggered;
    }
}