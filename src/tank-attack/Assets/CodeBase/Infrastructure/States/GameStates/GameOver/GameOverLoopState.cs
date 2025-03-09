using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Meta.UI;

namespace CodeBase.Infrastructure.States.GameStates.GameOver
{
    public class GameOverLoopState : SimpleState
    {
        private readonly LoadingCurtain _curtain;

        public GameOverLoopState(LoadingCurtain curtain)
        {
            _curtain = curtain;
        }
        
        public override void Enter()
        {
            _curtain.Hide();
        }
    }
}