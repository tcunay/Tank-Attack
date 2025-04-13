using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class SetHelicopterXAngleSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _helicopters;

        public SetHelicopterXAngleSystem(GameContext game)
        {
            _helicopters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Helicopter,
                    GameMatcher.WorldRotation,
                    GameMatcher.Direction,
                    GameMatcher.Moving,
                    GameMatcher.MovementAvailable
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _helicopters)
            {
                Vector3 eulerRotation = mover.WorldRotation.eulerAngles;

                mover.ReplaceWorldRotation(Quaternion.Euler(eulerRotation.SetX(30)));
            }
            
        }
    }
    
    public class SetDronAngleSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _helicopters;

        public SetDronAngleSystem(GameContext game)
        {
            _helicopters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dron,
                    GameMatcher.WorldRotation,
                    GameMatcher.Direction,
                    GameMatcher.Moving,
                    GameMatcher.MovementAvailable
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _helicopters)
            {
                Vector3 eulerRotation = mover.WorldRotation.eulerAngles;

                mover.ReplaceWorldRotation(Quaternion.Euler(eulerRotation.SetX(0).SetZ(0)));
            }
            
        }
    }
}