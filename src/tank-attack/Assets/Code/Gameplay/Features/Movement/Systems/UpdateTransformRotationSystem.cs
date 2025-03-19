using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateTransformRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _transforms;

        public UpdateTransformRotationSystem(GameContext gameContext)
        {
            _transforms = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.WorldRotation
                ));
        }
        
        public void Execute()
        {
            foreach (GameEntity target in _transforms)
            {
                target.Transform.rotation = target.WorldRotation;
            }
        }
    }
}