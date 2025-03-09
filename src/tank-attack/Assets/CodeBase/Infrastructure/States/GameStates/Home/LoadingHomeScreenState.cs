using CodeBase.Infrastructure.Loading;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;
using CodeBase.Meta.UI;

namespace CodeBase.Infrastructure.States.GameStates.Home
{
    public class LoadingHomeScreenState : SimpleState
    {
        private const string HomeScreenSceneName = "HomeScreen";
        
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadingHomeScreenState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }
    
        public override void Enter()
        {
            _curtain.Show();
            
            _sceneLoader.LoadScene(HomeScreenSceneName, EnterHomeScreenState);
        }

        private void EnterHomeScreenState()
        {
            _stateMachine.Enter<HomeScreenState>();
        }
    }
}