using System.Collections.Generic;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Compass.Systems
{
    public class RemoveMarkWithoutTargetSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _marksBuffer = new(16);
        private readonly IGroup<GameEntity> _compassMarks;

        public RemoveMarkWithoutTargetSystem(GameContext game)
        {
            _compassMarks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CompassMark
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mark in _compassMarks.GetEntities(_marksBuffer))
            {
                GameEntity enemy = mark.Target();

                if (enemy == null)
                {
                    mark.RemoveTargetId();
                    mark.isDestructed = true;
                }
                
            }
        }
    }
}