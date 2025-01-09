using CodeBase.Gameplay.Input;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CodeBase.Gameplay.Cameras.Components
{
    public class CameraZoom : MonoBehaviour
    {
        public Camera MainCamera;
        public float ZoomSpeed = 10f;
        public float MinFOV = 15f;
        public float MaxFOV = 60f;
        
        private IInputService _input;

        [Inject]
        private void Construct(IInputService input)
        {
            _input = input;
        }

        private void Update()
        {
            MainCamera.fieldOfView -=  _input.CameraZoomAxis * ZoomSpeed;
            MainCamera.fieldOfView = Mathf.Clamp(MainCamera.fieldOfView, MinFOV, MaxFOV);
        }
    }
}