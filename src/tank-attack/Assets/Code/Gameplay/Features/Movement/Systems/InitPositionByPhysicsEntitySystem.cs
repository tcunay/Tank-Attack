using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class InitPositionByPhysicsEntitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rigidbodyMovers;
        private readonly List<GameEntity> _moversBuffer = new List<GameEntity>(16);

        public InitPositionByPhysicsEntitySystem(GameContext game)
        {
            _rigidbodyMovers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rigidbody,
                    GameMatcher.PhysicalMover,
                    GameMatcher.WorldPosition,
                    GameMatcher.WorldRotation
                )
                .NoneOf(GameMatcher.InitPositionPhysicalMover));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _rigidbodyMovers.GetEntities(_moversBuffer))
            {
                mover.Rigidbody.position = mover.WorldPosition;
                mover.Rigidbody.rotation = Quaternion.Euler(mover.WorldRotation);
                mover.isInitPositionPhysicalMover = true;
            }
        }
    }
}