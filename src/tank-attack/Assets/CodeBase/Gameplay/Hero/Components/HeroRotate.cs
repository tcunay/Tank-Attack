using CodeBase.Common;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Time;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Hero.Components
{
    public class HeroRotate : MonoBehaviour
    {
        private const float RotationSpeed = 50f;
        private const float ClampAngle = 70f;
        
        private IInputService _inputService;
        private ITimeService _time;

        [Inject]
        private void Construct(IInputService inputService, ITimeService timeService)
        {
            _time = timeService;
            _inputService = inputService;
        }

        private void LateUpdate()
        {
            if (_inputService.Axis.sqrMagnitude < Constants.Epsilon)
                return;
            
            Vector3 euler = GetNormalizeLocalEulerAngles();

            float speed = RotationSpeed * _time.DeltaTime;
            Vector2 angleDelta = _inputService.Axis * speed;

            euler.x = Mathf.Clamp(euler.x - angleDelta.y, -ClampAngle, ClampAngle);
            euler.y += angleDelta.x;

            transform.localEulerAngles = new Vector3(euler.x, euler.y, 0f);
        }

        private Vector3 GetNormalizeLocalEulerAngles()
        {
            Vector3 euler = transform.localEulerAngles;
            
            euler.x = euler.x > 180f ? euler.x - 360f : euler.x;
            euler.y = euler.y > 180f ? euler.y - 360f : euler.y;

            return euler;
        }
    }
}