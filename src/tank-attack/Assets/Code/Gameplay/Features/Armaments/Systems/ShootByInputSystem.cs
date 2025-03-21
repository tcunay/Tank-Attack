using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Armaments.Setup;
using Code.Gameplay.Levels;
using Entitas;
using UnityEngine;

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
                .AllOf(GameMatcher.Hero, GameMatcher.WorldPosition, GameMatcher.CurrentBulletsCount));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (InputEntity input in _inputs)
            {
                if (hero.CurrentBulletsCount <= 0)
                {
                    continue;
                }
                
                ProjectileSetup projectileSetup = _levelDataProvider.LevelConfig.ArmamentSetup.ProjectileSetup;
                
                Vector3 forward = hero.WorldRotation * Vector3.forward;
                _projectileFactory.CreateBullet(hero.WorldPosition, forward, projectileSetup);
            }
        }
    }
}