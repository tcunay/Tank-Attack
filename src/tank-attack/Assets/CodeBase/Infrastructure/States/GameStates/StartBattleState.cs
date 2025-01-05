using Code.Gameplay.Levels;
using CodeBase.Gameplay.Hero.Factory;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;

namespace CodeBase.Infrastructure.States.GameStates
{
    public class StartBattleState : SimpleState
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IGameStateMachine _stateMachine;

        public StartBattleState(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider, IGameStateMachine stateMachine)
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
            _stateMachine = stateMachine;
        }
    
        public override void Enter()
        {
            _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            _stateMachine.Enter<BattleLoopState>();
        }
    }
}