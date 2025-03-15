using UnityEngine;

namespace Code.Gameplay.Cameras.Factory
{
    public interface ICameraFactory
    {
        GameEntity CreateCamera();
    }
}