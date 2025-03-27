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
        private readonly IGroup<GameEntity> _aims;

        public ShootByInputSystem(InputContext inputContext, GameContext gameContext, IProjectileFactory projectileFactory, ILevelDataProvider levelDataProvider)
        {
            _projectileFactory = projectileFactory;
            _levelDataProvider = levelDataProvider;

            _inputs = inputContext.GetGroup(InputMatcher
                .AllOf(InputMatcher.Input, InputMatcher.AttackInput));
            
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.WorldPosition, GameMatcher.CurrentBulletsCount));
            
            _aims = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Aim, GameMatcher.WorldPosition, GameMatcher.Direction));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity aim in _aims)
            foreach (InputEntity input in _inputs)
            {
                if (hero.CurrentBulletsCount <= 0)
                {
                    continue;
                }
                
                ProjectileSetup projectileSetup = _levelDataProvider.LevelConfig.ArmamentSetup.ProjectileSetup;

                if (aim.isAutoHoming)
                {
                    _projectileFactory.CreateAutoHomingBullet(aim.WorldPosition, aim.Direction, projectileSetup,
                        aim.DetectedTargetId);
                }
                else
                {
                    _projectileFactory.CreateBullet(aim.WorldPosition, aim.Direction, projectileSetup);
                }
            }
        }
    }
}