using Code.Gameplay.Input.Services;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
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

        private void Start()
        {
            OnSliderValueChanged(_slider.value);
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
            Debug.Log($"Value changed = {value}");
            Deselect();
            _inputService.CameraZoomAxis = value;
        }

        private void Deselect()
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}