using System;
using CodeBase.Gameplay.Input.Generated;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Input.Services
{
    public class InputService : IInputService , IInitializable, IDisposable
    {
        private readonly PlayerInputActions _playerInput;
        
        protected InputService()
        {
            _playerInput = new PlayerInputActions();
        }
        
        public float CameraZoomAxis { get; set; }
        public Vector2 Axis => _playerInput.Player.Move.ReadValue<Vector2>();
        public bool HasAxisInput() => Axis != Vector2.zero;

        public bool IsAttackButton() => _playerInput.Player.Attack.triggered;
        
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