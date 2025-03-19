using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MoveRotationRigidbodyByDirection : IExecuteSystem
    {
        private const float RotationSpeed = 300f;
        
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _rigidbodyMovers;

        public MoveRotationRigidbodyByDirection(GameContext game, ITimeService time)
        {
            _time = time;
            _rigidbodyMovers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rigidbody,
                    GameMatcher.PhysicalMover,
                    GameMatcher.Direction,
                    GameMatcher.Moving,
                    GameMatcher.MovementAvailable
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _rigidbodyMovers)
            {
                SmoothRotate(mover.Direction, mover.Rigidbody);
            }
            
        }
        
        private void SmoothRotate(Vector3 direction, Rigidbody rigidbody)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rigidbody.MoveRotation(Quaternion.Slerp(rigidbody.rotation, targetRotation, RotationSpeed * _time.DeltaTime));
        }
    }
}