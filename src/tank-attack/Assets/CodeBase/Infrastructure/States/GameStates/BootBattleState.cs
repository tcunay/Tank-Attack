using Code.Gameplay.Levels;
using Code.Gameplay.Levels.Setup;
using CodeBase.Gameplay.StaticData;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;

namespace CodeBase.Infrastructure.States.GameStates
{
    public class BootBattleState : SimpleState
    {
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootBattleState(ILevelDataProvider levelDataProvider, IGameStateMachine stateMachine, IStaticDataService staticDataService)
        {
            _levelDataProvider = levelDataProvider;
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
        }

        public override void Enter()
        {
            LevelConfig levelConfig = _staticDataService.GetLevelConfig(1);
            _levelDataProvider.SetLevelConfig(levelConfig);
            
            _stateMachine.Enter<LoadingBattleState>();
        }
    }
}