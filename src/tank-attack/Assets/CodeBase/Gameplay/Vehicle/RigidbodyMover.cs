using System;
using CodeBase.Gameplay.Time;
using CodeBase.Gameplay.Vehicle.View;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Vehicle
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
            _rigidbody.AddForce(_mover.Direction * _mover.SetupData.Speed, ForceMode.Force);
        }

        private void Update()
        {
            SmoothRotate(_mover.Direction);
        }

        private void SmoothRotate(Vector3 direction)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * _time.DeltaTime);
        }
    }
}