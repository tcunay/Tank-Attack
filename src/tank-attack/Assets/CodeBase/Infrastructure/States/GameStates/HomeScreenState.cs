using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Meta.UI;

namespace CodeBase.Infrastructure.States.GameStates
{
    public class HomeScreenState : SimpleState
    {
        private readonly LoadingCurtain _loadingCurtain;

        public HomeScreenState(LoadingCurtain loadingCurtain)
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