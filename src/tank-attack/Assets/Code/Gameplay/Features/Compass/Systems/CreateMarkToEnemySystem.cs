using System.Collections.Generic;
using Code.Gameplay.Features.Compass.Factory;
using Entitas;

namespace Code.Gameplay.Features.Compass.Systems
{
    public class CreateMarkToEnemySystem : IExecuteSystem
    {
        private readonly List<GameEntity> _enemiesBuffer = new(16);
        
        private readonly IMarkFactory _markFactory;
        
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _compasses;

        public CreateMarkToEnemySystem(GameContext game, IMarkFactory markFactory)
        {
            _markFactory = markFactory;
            
            _enemies = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Enemy)
                .NoneOf(GameMatcher.Marked));

            _compasses = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.CompassView));
        }

        public void Execute()
        {
            foreach (GameEntity compass in _compasses)
            foreach (GameEntity enemy in _enemies.GetEntities(_enemiesBuffer))
            {
                _markFactory
                    .CreateMark()
                    .AddInstantiateParent(compass.CompassView.MarkParent)
                    .AddTargetId(enemy.Id);
                
                enemy.isMarked = true;
            }
        }
    }
}