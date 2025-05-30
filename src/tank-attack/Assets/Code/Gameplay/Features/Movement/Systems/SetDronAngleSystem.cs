using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class SetDronAngleSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _drons;

        public SetDronAngleSystem(GameContext game)
        {
            _drons = game.GetGroup(GameMatcher
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
            foreach (GameEntity mover in _drons)
            {
                Vector3 eulerRotation = mover.WorldRotation.eulerAngles;

                mover.ReplaceWorldRotation(Quaternion.Euler(eulerRotation.SetX(0).SetZ(0)));
            }
            
        }
    }
}