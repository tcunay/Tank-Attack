using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Camera.Registrars
{
    public class CameraRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private UnityEngine.Camera _camera;
        
        public override void RegisterComponents()
        {
            Entity.AddCameraUnity(_camera);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasCameraUnity)
                Entity.RemoveCameraUnity();
        }
    }
}