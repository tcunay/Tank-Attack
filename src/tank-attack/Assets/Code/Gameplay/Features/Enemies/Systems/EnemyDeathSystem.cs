using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;

        public EnemyDeathSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy, 
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath
                ));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                enemy.isDestructed = true;
            }
        }
    }
}