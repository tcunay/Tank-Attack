using Code.Common;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Services
{
    public class SetHeroAngleByInputSystem : IExecuteSystem
    {
        private const float RotationSpeed = 50f;
        private const float ClampAngle = 70f;
        
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<InputEntity> _inputs;

        public SetHeroAngleByInputSystem(GameContext game, InputContext inputContext, ITimeService time)
        {
            _time = time;
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.Rotation));
            
            _inputs = inputContext.GetGroup(InputMatcher
                .AllOf(InputMatcher.Input, InputMatcher.AxisInput));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (InputEntity input in _inputs)
            {
                if (input.AxisInput.sqrMagnitude < Constants.Epsilon)
                {
                    continue;
                }
                
                Vector3 euler = GetNormalizeLocalEulerAngles(hero.Rotation);
                
                float speed = RotationSpeed * _time.DeltaTime;
                Vector2 angleDelta = input.AxisInput * speed;

                euler.x = Mathf.Clamp(euler.x - angleDelta.y, -ClampAngle, ClampAngle);
                euler.y += angleDelta.x;

                hero.ReplaceRotation(new Vector3(euler.x, euler.y, 0f));
            }
        }

        private Vector3 GetNormalizeLocalEulerAngles(Vector3 euler)
        {
            
            euler.x = euler.x > 180f ? euler.x - 360f : euler.x;
            euler.y = euler.y > 180f ? euler.y - 360f : euler.y;

            return euler;
        }
    }
}