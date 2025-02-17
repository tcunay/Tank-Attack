using System;
using CodeBase.Gameplay.Vehicle.View;
using UnityEngine;

namespace CodeBase.Gameplay.Vehicle
{
    public class RigidbodyMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private WayPointsMove _mover;
        
        private const float RotationSpeed = 3f;

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_mover.Direction * _mover.SetupData.Speed, ForceMode.Force);
            //_rigidbody.MoveRotation();
        }
    }
}