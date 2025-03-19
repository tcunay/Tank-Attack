using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateWorldRotationToPhysicalMovers : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rigidbodyMovers;

        public UpdateWorldRotationToPhysicalMovers(GameContext game)
        {
            _rigidbodyMovers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.PhysicalMover,
                    GameMatcher.WorldRotation
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _rigidbodyMovers)
            {
                mover.ReplaceWorldRotation(mover.Transform.rotation.eulerAngles);
            }
        }
    }
}