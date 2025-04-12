using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class InitPrevHpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity>  _buffer = new(128);

        public InitPrevHpSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.CurrentHp)
                .NoneOf(GameMatcher.PrevHp));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.AddPrevHp(entity.CurrentHp);
            }
        }
    }
}