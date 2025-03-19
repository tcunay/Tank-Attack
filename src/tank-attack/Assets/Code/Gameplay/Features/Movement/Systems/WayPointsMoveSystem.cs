using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class WayPointsMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly List<GameEntity> _moversBuffer = new(16);

        public WayPointsMoveSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WayPointsMove,
                    GameMatcher.WayPointsMoveIndex,
                    GameMatcher.ArrivalThreshold,
                    GameMatcher.WorldPosition
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers.GetEntities(_moversBuffer))
            {
                int currentIndex = mover.WayPointsMoveIndex;
                Vector3 targetWaypoint = mover.WayPointsMove[currentIndex];

                if (IsReached(mover.WorldPosition, targetWaypoint, mover.ArrivalThreshold))
                {
                    currentIndex++;
                    
                    if (currentIndex >= mover.WayPointsMove.Length)
                    {
                        currentIndex = 0;
                    }
                    
                    mover.ReplaceWayPointsMoveIndex(currentIndex);
                }
                
                Vector3 direction = (mover.WayPointsMove[currentIndex] - mover.WorldPosition).normalized;
                mover.ReplaceDirection(direction);
            }
        }

        private bool IsReached(Vector3 position, Vector3 target, float arrivalThreshold)
        {
            return Vector3.Distance(position, target) < arrivalThreshold;
        }
    }
}