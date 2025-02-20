using CodeBase.Infrastructure.Loading;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;
using CodeBase.Meta.UI;

namespace CodeBase.Infrastructure.States.GameStates
{
    public class LoadingBattleState : SimplePayloadState<string>
    {
        
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadingBattleState(ISceneLoader sceneLoader, IGameStateMachine stateMachine, LoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _loadingCurtain = loadingCurtain;
        }

        public override void Enter(string payload)
        {
            _loadingCurtain.Show();
            _sceneLoader.LoadScene(payload, EnterBattleLoopState);
        }

        private void EnterBattleLoopState()
        {
            _stateMachine.Enter<StartBattleState>();
        }

    
    }
}