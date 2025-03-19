using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MoveRotationRigidbodyByDirection : IExecuteSystem
    {
        private const float RotationSpeed = 3f;
        
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _rigidbodyMovers;

        public MoveRotationRigidbodyByDirection(GameContext game, ITimeService time)
        {
            _time = time;
            _rigidbodyMovers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rigidbody,
                    GameMatcher.PhysicalMover,
                    GameMatcher.RotationSpeed,
                    GameMatcher.Direction,
                    GameMatcher.Moving,
                    GameMatcher.MovementAvailable
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _rigidbodyMovers)
            {
                Quaternion targetRotation = Quaternion.LookRotation(mover.Direction);
                mover.Rigidbody.MoveRotation(Quaternion.Slerp(mover.Rigidbody.rotation, targetRotation, mover.RotationSpeed * _time.DeltaTime));
            }
            
        }
    }
}