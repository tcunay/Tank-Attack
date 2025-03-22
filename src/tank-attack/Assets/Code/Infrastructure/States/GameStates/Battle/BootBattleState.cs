using Code.Gameplay.Levels;
using Code.Gameplay.Levels.Setup;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates.Battle
{
    public class BootBattleState : SimplePayloadState<int>
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

        public override void Enter(int level)
        {
            LevelConfig levelConfig = _staticDataService.GetLevelConfig(level);
            _levelDataProvider.SetLevelConfig(levelConfig);
            
            _stateMachine.Enter<LoadingBattleState>();
        }
    }
}