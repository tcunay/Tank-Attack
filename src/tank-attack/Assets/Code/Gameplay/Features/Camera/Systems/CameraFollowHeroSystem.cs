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
                        GameMatcher.Rotation
                    }));
            
            _cameras = gameContext.GetGroup(GameMatcher
                .AllOf(
                    matchers: new[]
                    {
                        GameMatcher.Camera,
                        GameMatcher.WorldPosition,
                        GameMatcher.Rotation
                    }));
        }
        
        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity camera in _cameras)
            {
                camera.ReplaceWorldPosition(hero.WorldPosition);
                camera.ReplaceRotation(hero.Rotation);
            }
        }
    }
}