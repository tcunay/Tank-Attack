using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class ProcessingTakeDamageSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _damages;
        private readonly List<GameEntity>  _buffer = new(128);

        public ProcessingTakeDamageSystem(GameContext game)
        {
            _damages = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.TakeDamage, GameMatcher.CurrentHp, GameMatcher.PrevHp));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _damages.GetEntities(_buffer))
            {
                entity.ReplacePrevHp(entity.CurrentHp);
                entity.ReplaceCurrentHp(entity.CurrentHp - entity.TakeDamage);
            }
        }
    }
}