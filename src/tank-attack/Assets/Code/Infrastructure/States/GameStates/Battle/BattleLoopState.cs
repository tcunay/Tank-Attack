using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta.UI;

namespace Code.Infrastructure.States.GameStates.Battle
{
    public class BattleLoopState : SimpleState
    {
        private readonly LoadingCurtain _loadingCurtain;

        public BattleLoopState(LoadingCurtain loadingCurtain)
        {
            _loadingCurtain = loadingCurtain;
        }

        public override void Enter()
        {
            base.Enter();
            _loadingCurtain.Hide();
        }
    }
}