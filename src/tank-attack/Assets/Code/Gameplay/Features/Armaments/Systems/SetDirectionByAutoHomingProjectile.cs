using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class SetDirectionByAutoHomingProjectile : IExecuteSystem
    {
        private readonly List<GameEntity> _bulletsBuffer = new(32);
        private readonly IGroup<GameEntity> _bullets;

        public SetDirectionByAutoHomingProjectile(GameContext game)
        {
            _bullets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.AutoHoming,
                    GameMatcher.DetectedTargetId,
                    GameMatcher.Direction,
                    GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (GameEntity bullet in _bullets.GetEntities(_bulletsBuffer))
            {
                GameEntity target = bullet.DetectedTarget();
                
                if (target == null || target.isDestructed)
                {
                    bullet.RemoveDetectedTargetId();
                    continue;
                }
                
                Vector3 targetPosition = target.WorldPosition - target.DirectionToCenter;
                bullet.ReplaceDirection((targetPosition - bullet.WorldPosition).normalized);
            }
        }
    }
}