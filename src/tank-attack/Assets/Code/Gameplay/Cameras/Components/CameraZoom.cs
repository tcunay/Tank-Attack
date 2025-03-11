using Code.Gameplay.Input;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cameras.Components
{
    public class CameraZoom : MonoBehaviour
    {
        public Camera MainCamera;
        public float MinFOV = 15f;
        public float MaxFOV = 80f;
        
        private IInputService _input;

        [Inject]
        private void Construct(IInputService input)
        {
            _input = input;
        }

        private void Update()
        {
            MainCamera.fieldOfView = Mathf.Lerp(MaxFOV, MinFOV, _input.CameraZoomAxis);
        }
    }
}