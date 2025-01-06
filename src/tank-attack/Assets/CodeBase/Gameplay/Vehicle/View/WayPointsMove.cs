using System;
using CodeBase.Gameplay.Time;
using CodeBase.Gameplay.Vehicle.Setup;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Vehicle.View
{
    public class WayPointsMove : MonoBehaviour
    {
        private const float ArrivalThreshold = 0.1f;

        private WayPointsMoveSetup _setup;
        private ITimeService _time;
        private int _currentWaypointIndex = 0;

        [Inject]
        private void Construct(ITimeService time)
        {
            _time = time;
        }

        public void Setup(WayPointsMoveSetup setup)
        {
            _setup = setup;
            transform.position = setup.WayPoints[0].position;
            _currentWaypointIndex = 0;
        }

        private void Update()
        {
            if (_setup == null)
            {
                return;
            }

            MoveTowardsWaypoint();
        }
        
        private void MoveTowardsWaypoint()
        {
            Transform targetWaypoint = _setup.WayPoints[_currentWaypointIndex];
            Vector3 direction = (targetWaypoint.position - transform.position).normalized;
            transform.forward = direction;
    
            // Перемещение объекта
            transform.position += direction * (_setup.Speed * _time.DeltaTime);

            // Проверка, достигли ли мы точки
            if (Vector3.Distance(transform.position, targetWaypoint.position) < ArrivalThreshold)
            {
                // Переходим к следующей точке
                _currentWaypointIndex++;
                if (_currentWaypointIndex >= _setup.WayPoints.Length)
                {
                    // Если достигли конца пути, можно либо зациклить, либо остановиться
                    _currentWaypointIndex = 0; // Зациклить
                    // или используйте return; для остановки
                }
            }
        }
    }
}