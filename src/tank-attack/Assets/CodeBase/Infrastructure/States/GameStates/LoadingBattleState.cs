using Code.Gameplay.Levels.Setup;
using CodeBase.Gameplay.StaticData;
using CodeBase.Infrastructure.Loading;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;
using CodeBase.Meta.UI;

namespace CodeBase.Infrastructure.States.GameStates
{
    public class LoadingBattleState : SimpleState
    {
        
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadingBattleState(ISceneLoader sceneLoader, IGameStateMachine stateMachine, IStaticDataService staticDataService, LoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
            _loadingCurtain = loadingCurtain;
        }

        public override void Enter()
        {
            LevelConfig levelConfig = _staticDataService.GetLevelConfig(1);
            _loadingCurtain.Show();
            _sceneLoader.LoadScene(levelConfig.SceneReference, () => EnterBattleLoopState(levelConfig));
        }

        private void EnterBattleLoopState(LevelConfig level)
        {
            _stateMachine.Enter<StartBattleState, LevelConfig>(level);
        }

    
    }
}