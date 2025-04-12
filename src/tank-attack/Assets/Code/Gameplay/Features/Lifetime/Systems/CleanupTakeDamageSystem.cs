using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class CleanupTakeDamageSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _damages;
        private readonly List<GameEntity>  _buffer = new(128);

        public CleanupTakeDamageSystem(GameContext game)
        {
            _damages = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.TakeDamage));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _damages.GetEntities(_buffer))
            {
                entity.RemoveTakeDamage();
            }
        }
    }
}