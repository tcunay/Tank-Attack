using Code.Infrastructure.Entitas;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class AddRigidbodyForceByDirection : IFixedExecuteSystem
    {
        private readonly IGroup<GameEntity> _rigidbodyMovers;

        public AddRigidbodyForceByDirection(GameContext game)
        {
            _rigidbodyMovers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rigidbody,
                    GameMatcher.PhysicalMover,
                    GameMatcher.Speed,
                    GameMatcher.Direction,
                    GameMatcher.Moving,
                    GameMatcher.MovementAvailable
                ));
        }

        public void FixedExecute()
        {
            foreach (GameEntity mover in _rigidbodyMovers)
            {
                mover.Rigidbody.AddForce(mover.Direction.normalized * mover.Speed, ForceMode.Force);
            }
        }

    }
}