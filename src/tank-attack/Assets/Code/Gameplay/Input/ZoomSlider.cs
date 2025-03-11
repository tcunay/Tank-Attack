using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Input
{
    public class ZoomSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Awake()
        {
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
        }
        
        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float value)
        {
            _inputService.CameraZoomAxis = value;
        }
    }
}