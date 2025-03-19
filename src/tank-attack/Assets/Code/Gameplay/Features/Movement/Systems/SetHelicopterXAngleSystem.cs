using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class SetHelicopterXAngleSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rigidbodyMovers;

        public SetHelicopterXAngleSystem(GameContext game)
        {
            _rigidbodyMovers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Helicopter,
                    GameMatcher.WorldRotation,
                    GameMatcher.Direction,
                    GameMatcher.Moving,
                    GameMatcher.MovementAvailable
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _rigidbodyMovers)
            {
                Vector3 eulerRotation = mover.WorldRotation.eulerAngles;

                mover.ReplaceWorldRotation(Quaternion.Euler(eulerRotation.SetX(30)));
            }
            
        }
    }
}