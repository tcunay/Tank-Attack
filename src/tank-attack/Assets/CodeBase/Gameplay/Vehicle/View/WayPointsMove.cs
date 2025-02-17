using CodeBase.Gameplay.Time;
using CodeBase.Gameplay.Vehicle.Setup;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Vehicle.View
{
    public class WayPointsMove : MonoBehaviour
    {
        private const float ArrivalThreshold = 1f;
        private const float RotationSpeed = 3f;

        private WayPointsMoveSetup _setup;
        private ITimeService _time;
        private int _currentWaypointIndex = 0;

        public WayPointsMoveSetup SetupData => _setup;
        public Vector3 Direction { get; private set; }

        [Inject]
        private void Construct(ITimeService time)
        {
            _time = time;
        }

        public void Setup(WayPointsMoveSetup setup)
        {
            _setup = setup;
            transform.position = setup.WayPoints[0].position;
            transform.forward = (setup.WayPoints[1].position - transform.position).normalized;
            _currentWaypointIndex = 0; 
        }

        private void Update()
        {
            MoveTowardsWaypoint();
        }
        
        private void MoveTowardsWaypoint()
        {
            Transform targetWaypoint = _setup.WayPoints[_currentWaypointIndex];
            Vector3 direction = (targetWaypoint.position - transform.position).normalized;
            
            SmoothRotate(direction);
            
            //AddPosition(direction * (_setup.Speed * _time.DeltaTime));
            Direction = direction;

            if (IsReached(targetWaypoint.position))
            {
                _currentWaypointIndex++;
                if (_currentWaypointIndex >= _setup.WayPoints.Length)
                {
                    _currentWaypointIndex = 0;
                }
            }
        }
        
        private bool IsReached(Vector3 position)
        {
            return Vector3.Distance(transform.position, position) < ArrivalThreshold;
        }

        private void AddPosition(Vector3 addPosition)
        {
            transform.position += addPosition;
        }

        private void SmoothRotate(Vector3 direction)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * _time.DeltaTime);
        }
    }
}
