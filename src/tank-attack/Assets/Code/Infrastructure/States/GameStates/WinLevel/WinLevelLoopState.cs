using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta.UI;

namespace Code.Infrastructure.States.GameStates.WinLevel
{
    public class WinLevelLoopState : SimpleState
    {
        private readonly LoadingCurtain _curtain;

        public WinLevelLoopState(LoadingCurtain curtain)
        {
            _curtain = curtain;
        }
        
        public override void Enter()
        {
            _curtain.Hide();
        }
    }
}