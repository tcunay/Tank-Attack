using CodeBase.Gameplay.StaticData;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Loading;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;
using CodeBase.Meta.UI;

namespace CodeBase.Infrastructure.States.GameStates.GameOver
{
    public class LoadingGameOverState : SimpleState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadingGameOverState(
            ISceneLoader sceneLoader,
            IGameStateMachine stateMachine,
            IStaticDataService staticDataService,
            LoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
            _loadingCurtain = loadingCurtain;
        }
        
        public override void Enter()
        {
            _loadingCurtain.Show();
            
            _sceneLoader.LoadSceneAsset(AssetPath.GameOverScene);
        }
    }
}