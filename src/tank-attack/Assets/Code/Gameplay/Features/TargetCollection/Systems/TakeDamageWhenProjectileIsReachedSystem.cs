using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class TakeDamageWhenProjectileIsReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _projectiles;
        private readonly IGroup<GameEntity> _enemies;

        public TakeDamageWhenProjectileIsReachedSystem(GameContext game)
        {
            _projectiles = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Projectile, GameMatcher.TargetsBuffer, GameMatcher.Reached));

            _enemies = game.GetGroup(GameMatcher.Enemy);
        }

        public void Execute()
        {
            foreach (GameEntity projectile in _projectiles)
            foreach (int targetId in projectile.TargetsBuffer)
            foreach (GameEntity enemy in _enemies)
            {
                if (enemy.Id == targetId)
                {
                    enemy.isDestructed = true;
                }
            }
        }
    }
}