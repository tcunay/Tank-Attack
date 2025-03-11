using UnityEngine;

namespace Code.Gameplay.Cameras.Factory
{
    public interface ICameraFactory
    {
        Camera CreateCamera();
    }
}