using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateRotationToPhysicalMovers : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rigidbodyMovers;

        public UpdateRotationToPhysicalMovers(GameContext game)
        {
            _rigidbodyMovers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rigidbody,
                    GameMatcher.PhysicalMover,
                    GameMatcher.Rotation
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _rigidbodyMovers)
            {
                mover.ReplaceRotation(mover.Rigidbody.rotation.eulerAngles);
            }
        }
    }
}