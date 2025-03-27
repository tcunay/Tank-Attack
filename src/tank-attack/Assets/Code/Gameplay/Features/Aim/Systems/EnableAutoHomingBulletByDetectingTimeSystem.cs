using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Aim.Systems
{
    public class EnableAutoHomingBulletByDetectingTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _aims;

        public EnableAutoHomingBulletByDetectingTimeSystem(GameContext game)
        {
            _aims = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Aim,
                    GameMatcher.DetectionTime,
                    GameMatcher.MaxDetectingTime
                ));
        }

        public void Execute()
        {
            foreach (GameEntity aim in _aims)
            {
                bool isAutoHoming = aim.isAutoHoming;
                aim.isAutoHoming = aim.DetectionTime >= aim.MaxDetectingTime;

                if (aim.isAutoHoming && isAutoHoming == false)
                {
                    Debug.Log("Enable AutoHoming");
                }
            }
        }
    }
}