using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta.UI;

namespace Code.Infrastructure.States.GameStates.Home
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