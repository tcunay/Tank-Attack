using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.Camera.Systems
{
    public class CameraFollowHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _cameras;

        public CameraFollowHeroSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    matchers: new[]
                    {
                        GameMatcher.Hero,
                        GameMatcher.WorldPosition,
                        GameMatcher.WorldRotation
                    }));
            
            _cameras = gameContext.GetGroup(GameMatcher
                .AllOf(
                    matchers: new[]
                    {
                        GameMatcher.MainCamera,
                        GameMatcher.WorldPosition,
                        GameMatcher.WorldRotation
                    }));
        }
        
        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity camera in _cameras)
            {
                camera.ReplaceWorldPosition(hero.WorldPosition);
                camera.ReplaceWorldRotation(hero.WorldRotation);
            }
        }
    }
}