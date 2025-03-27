using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Aim.Systems
{
    public class SetAimDirectionByHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _aims;
        private readonly IGroup<GameEntity> _heroes;

        public SetAimDirectionByHeroSystem(GameContext game)
        {
            _aims = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Aim, GameMatcher.Direction, GameMatcher.WorldPosition));
            
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.WorldRotation, GameMatcher.WorldPosition));
            
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity aim in _aims)
            {
                aim.ReplaceWorldPosition(hero.WorldPosition);
                aim.ReplaceDirection(hero.WorldRotation * Vector3.forward);
            }
        }
    }
}