using CodeBase.Common;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Time;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Shooter.View
{
    public class ShooterMove : MonoBehaviour
    {
        private IInputService _inputService;
        private ITimeService _time;

        private const float RotationSpeed = 100f;

        [Inject]
        private void Construct(IInputService inputService, ITimeService timeService)
        {
            _time = timeService;
            _inputService = inputService;
        }

        private void LateUpdate()
        {
            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                float speed = RotationSpeed * _time.DeltaTime;
                Vector2 angle = _inputService.Axis * speed;
                
                transform.rotation = Quaternion
                    .Euler(transform.rotation.eulerAngles.x - angle.y,
                        transform.rotation.eulerAngles.y + angle.x, 0f);
            }
        }
    }
}