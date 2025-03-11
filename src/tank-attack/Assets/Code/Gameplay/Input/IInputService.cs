using UnityEngine;

namespace Code.Gameplay.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        float CameraZoomAxis { get; set; }
        bool IsAttackButton();
    }
}