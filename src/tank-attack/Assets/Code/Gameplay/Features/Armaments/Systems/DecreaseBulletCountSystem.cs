using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class DecreaseBulletCountSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _heroes;

        public DecreaseBulletCountSystem(GameContext game) : base(game)
        {
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.CurrentBulletsCount));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Projectile.Added());

        protected override bool Filter(GameEntity entity) => entity.isProjectile;
        protected override void Execute(List<GameEntity> projectiles)
        {
            
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity projectile in projectiles)
            {
                hero.ReplaceCurrentBulletsCount(hero.CurrentBulletsCount - 1);
            }
        }
    }
}