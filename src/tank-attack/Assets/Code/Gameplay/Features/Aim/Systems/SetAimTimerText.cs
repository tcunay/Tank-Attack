using Entitas;

namespace Code.Gameplay.Features.Aim.Systems
{
    public class SetAimTimerText : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _aims;
        private readonly IGroup<GameEntity> _timers;

        public SetAimTimerText(GameContext game)
        {
            _aims = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Aim,
                    GameMatcher.DetectionTime,
                    GameMatcher.MaxDetectingTime
                ));
            
            _timers =game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AutoHomingTimerText
                ));
        }

        public void Execute()
        {
            foreach (GameEntity aim in _aims)
            foreach (GameEntity timer in _timers)
            {
                float timeLeft = aim.MaxDetectingTime - aim.DetectionTime;

                string timerText = timeLeft.ToString("F1");
                
                if (timeLeft <= 0)
                {
                    timerText = "Самонаводящиеся пули включены";
                }
                
                timer.AutoHomingTimerText.text = timerText;
            }
        }
    }
}