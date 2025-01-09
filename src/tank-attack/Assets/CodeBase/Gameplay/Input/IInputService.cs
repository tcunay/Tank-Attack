using UnityEngine;

namespace CodeBase.Gameplay.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        float CameraZoomAxis { get; }

        bool IsAttackButton();
    }
}