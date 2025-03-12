using UnityEngine;

namespace Code.Gameplay.Input.Services
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        float CameraZoomAxis { get; set; }
        bool HasAxisInput();
        bool IsAttackButton();
    }
}