using System;
using CodeBase.Gameplay.Input.Generated;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Input
{
    public class InputService : IInputService , IInitializable, IDisposable
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
        
        public void Initialize()
        {
            _playerInput.Player.Enable();
        }

        public void Dispose()
        {
            _playerInput?.Disable();
            _playerInput?.Dispose();
        }
    }
}