using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class ProjectileMarkDestructedWhenReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _projectiles;

        public ProjectileMarkDestructedWhenReachedSystem(GameContext game)
        {
            _projectiles = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Projectile, GameMatcher.Reached));
        }

        public void Execute()
        {
            foreach (GameEntity projectile in _projectiles)
            {
                projectile.isDestructed = true;
            }
        }
    }
}