using UnityEngine;

namespace CodeBase.Gameplay.Cameras.Factory
{
    public interface ICameraFactory
    {
        Camera CreateCamera();
    }
}