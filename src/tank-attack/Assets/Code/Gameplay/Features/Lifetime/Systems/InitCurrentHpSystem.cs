using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class InitCurrentHpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity>  _buffer = new(128);

        public InitCurrentHpSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.MaxHp)
                .NoneOf(GameMatcher.CurrentHp));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.AddCurrentHp(entity.MaxHp);
            }
        }
    }
}