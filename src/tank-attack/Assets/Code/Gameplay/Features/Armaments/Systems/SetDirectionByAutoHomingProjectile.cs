using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class SetDirectionByAutoHomingProjectile : IExecuteSystem
    {
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
            foreach (GameEntity bullet in _bullets)
            {
                Vector3 targetPosition = bullet.Target().WorldPosition;
                bullet.ReplaceDirection((targetPosition - bullet.WorldPosition).normalized);
            }
        }
    }
}