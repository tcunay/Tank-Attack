using Code.Gameplay.Levels;
using Code.Gameplay.Levels.Setup;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI;

namespace Code.Infrastructure.States.GameStates.Battle
{
    public class LoadingBattleState : SimplePayloadState<int>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadingBattleState(
            ISceneLoader sceneLoader,
            IGameStateMachine stateMachine,
            ILevelDataProvider levelDataProvider,
            IStaticDataService staticDataService,
            LoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _loadingCurtain = loadingCurtain;
            _levelDataProvider = levelDataProvider;
            _staticDataService = staticDataService;
        }

        public override void Enter(int level)
        {
            _loadingCurtain.Show();
            
            LevelConfig levelConfig = _staticDataService.GetLevelConfig(level);
            _levelDataProvider.SetLevelConfig(levelConfig);
            
            _sceneLoader.LoadSceneAsset(_levelDataProvider.LevelConfig.SceneReference, LoadingButtonState);
        }

        private void LoadingButtonState()
        {
            _stateMachine.Enter<BattleEnterState>();
        }
    }
}