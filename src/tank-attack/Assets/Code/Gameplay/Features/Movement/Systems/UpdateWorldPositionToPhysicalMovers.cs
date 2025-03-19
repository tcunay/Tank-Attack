using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateWorldPositionToPhysicalMovers : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rigidbodyMovers;

        public UpdateWorldPositionToPhysicalMovers(GameContext game)
        {
            _rigidbodyMovers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.PhysicalMover,
                    GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _rigidbodyMovers)
            {
                mover.ReplaceWorldPosition(mover.Transform.position);
            }
        }
    }
}