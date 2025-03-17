using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class WayPointsMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly List<GameEntity> _moversBuffer = new(8);

        public WayPointsMoveSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.WayPointsMove, GameMatcher.ArrivalThreshold));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers.GetEntities(_moversBuffer))
            {
                Vector3 targetWaypoint = mover.WayPointsMove.Value;

                if (IsReached(mover.WorldPosition, targetWaypoint, mover.ArrivalThreshold))
                {
                    mover.ReplaceWayPointsMove(mover.WayPointsMove.Next);
                }
                
                Vector3 direction = (mover.WayPointsMove.Value - mover.WorldPosition).normalized;
                mover.ReplaceDirection(direction);
            }
        }

        private bool IsReached(Vector3 position, Vector3 target, float arrivalThreshold)
        {
            return Vector3.Distance(position, target) < arrivalThreshold;
        }
    }
}