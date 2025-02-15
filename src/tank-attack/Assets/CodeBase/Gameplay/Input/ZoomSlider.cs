using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Gameplay.Input
{
    public class ZoomSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        private readonly SimpleInput.AxisInput _yAxis = new( "SimpleInputZoom" );

        private void OnEnable()
        {
            _yAxis.StartTracking();

            SimpleInput.OnUpdate += OnUpdate;
        }

        private void OnUpdate()
        {
            
        }

        private void OnDisable()
        {
            _yAxis.StopTracking();

            SimpleInput.OnUpdate -= OnUpdate;
        }

        private void Update()
        {
            _yAxis.value = _slider.value;
        }
    }
}