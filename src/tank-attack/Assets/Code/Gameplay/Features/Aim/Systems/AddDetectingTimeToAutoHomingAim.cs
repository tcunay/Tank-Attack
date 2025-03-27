using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Aim.Systems
{
    public class AddDetectingTimeToAutoHomingAim : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _aims;

        public AddDetectingTimeToAutoHomingAim(GameContext game, ITimeService time)
        {
            _time = time;
            _aims = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Aim));
        }

        public void Execute()
        {
            foreach (GameEntity aim in _aims)
            {
                if (aim.hasDetectedTargetId)
                {
                    if (aim.hasDetectingTargetId && aim.DetectedTargetId == aim.DetectingTargetId)
                    {
                        aim.ReplaceDetectionTime(aim.DetectionTime + _time.DeltaTime);
                    }
                    else
                    {
                        aim.ReplaceDetectingTargetId(aim.DetectedTargetId);
                        aim.ReplaceDetectionTime(0);
                    }
                }
                else
                {
                    aim.ReplaceDetectionTime(0);
                }
            }
        }
    }
}