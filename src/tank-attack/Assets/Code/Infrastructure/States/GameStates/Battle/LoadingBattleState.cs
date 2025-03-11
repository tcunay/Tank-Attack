using Code.Gameplay.Levels;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI;

namespace Code.Infrastructure.States.GameStates.Battle
{
    public class LoadingBattleState : SimpleState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadingBattleState(
            ISceneLoader sceneLoader,
            IGameStateMachine stateMachine,
            ILevelDataProvider levelDataProvider,
            LoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _loadingCurtain = loadingCurtain;
            _levelDataProvider = levelDataProvider;
        }

        public override void Enter()
        {
            _loadingCurtain.Show();
            
            _sceneLoader.LoadSceneAsset(_levelDataProvider.LevelConfig.SceneReference);
        }
    }
}