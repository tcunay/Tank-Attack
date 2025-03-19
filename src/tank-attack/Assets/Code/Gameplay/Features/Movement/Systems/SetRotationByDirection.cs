using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class SetRotationByDirection : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _rigidbodyMovers;

        public SetRotationByDirection(GameContext game, ITimeService time)
        {
            _time = time;
            _rigidbodyMovers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldRotation,
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
                mover.ReplaceWorldRotation(Quaternion.Slerp(mover.WorldRotation,  targetRotation, mover.RotationSpeed * _time.DeltaTime));
            }
            
        }
    }
}