using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Armaments.Setup;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class ShootByInputSystem : IExecuteSystem
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly ILevelDataProvider _levelDataProvider;

        private readonly IGroup<InputEntity> _inputs;
        private readonly IGroup<GameEntity> _heroes;

        public ShootByInputSystem(InputContext inputContext, GameContext gameContext, IProjectileFactory projectileFactory, ILevelDataProvider levelDataProvider)
        {
            _projectileFactory = projectileFactory;
            _levelDataProvider = levelDataProvider;

            _inputs = inputContext.GetGroup(InputMatcher
                .AllOf(InputMatcher.Input, InputMatcher.AttackInput));
            
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (InputEntity input in _inputs)
            {
                ProjectileSetup projectileSetup = _levelDataProvider.LevelConfig.ArmamentSetup.ProjectileSetup;
                
                _projectileFactory.CreateBullet(hero.WorldPosition, hero.Rotation, projectileSetup);
            }
        }
    }
}