using Code.Gameplay.Vehicle.Setup;
using UnityEngine;

namespace Code.Gameplay.Vehicle.Components
{
    public class WayPointsMove : MonoBehaviour
    {
        [SerializeField] private float _arrivalThreshold = 1f;

        private WayPointsMoveSetup _setup;
        private int _currentWaypointIndex;

        public WayPointsMoveSetup SetupData => _setup;
        public Vector3 NormalizedDirection { get; private set; }
        public Vector3 Direction { get; private set; }

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
            Direction = (targetWaypoint.position - transform.position);
            NormalizedDirection = Direction.normalized;

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
            return Vector3.Distance(transform.position, position) < _arrivalThreshold;
        }
    }
}