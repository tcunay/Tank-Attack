using Code.Gameplay.Common.Time;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Vehicle.Components
{
    public class RigidbodyMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private WayPointsMove _mover;
        private ITimeService _time;

        private const float RotationSpeed = 3f;

        [Inject]
        private void Construct(ITimeService time)
        {
            _time = time;
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_mover.NormalizedDirection * _mover.SetupData.Speed, ForceMode.Force);
        }

        private void Update()
        {
            SmoothRotate(_mover.NormalizedDirection);
        }

        private void SmoothRotate(Vector3 direction)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * _time.DeltaTime);
        }
    }
}