using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Vehicle.Components
{
    public class HelicopterMover : MonoBehaviour
    {
        [SerializeField] private WayPointsMove _mover;
        [SerializeField] private HelicopterController _controller;
        
        private readonly List<PressedKeyCode> _pressedKeysCash = new(8);
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 direction = _mover.Direction;
            _pressedKeysCash.Clear();
            // Проверяем направление по Y
            if (direction.y > 0.5f)
            {
                _pressedKeysCash.Add(PressedKeyCode.SpeedUpPressed);
            }
            else if (direction.y < -0.5f)
            {
                _pressedKeysCash.Add(PressedKeyCode.SpeedDownPressed);
            }

            // Пример для движения вперёд/назад
            float forwardDot = Vector3.Dot(transform.forward, direction.normalized);
            
            if (forwardDot > 0.2f)
            {
                _pressedKeysCash.Add(PressedKeyCode.ForwardPressed);
            }
            else if (forwardDot < -0.2f)
            {
                _pressedKeysCash.Add(PressedKeyCode.BackPressed);
            }

            // Пример для поворота (SignedAngle)
            float angle = Vector3.SignedAngle(
                transform.forward, 
                direction, 
                Vector3.up
            );
            
            if (angle > 45f)
            {
                _pressedKeysCash.Add(PressedKeyCode.TurnRightPressed);
            }
            else if (angle < -45f)
            {
                _pressedKeysCash.Add(PressedKeyCode.TurnLeftPressed);
            }

            // Отправляем нажатия
            _controller.OnKeyPressed(_pressedKeysCash);
        }
    }
}