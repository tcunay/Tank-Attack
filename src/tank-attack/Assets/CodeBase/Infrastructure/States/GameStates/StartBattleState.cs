using Code.Gameplay.Levels;
using CodeBase.Gameplay.Shooter.Factory;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;

namespace CodeBase.Infrastructure.States.GameStates
{
    public class StartBattleState : SimpleState
    {
        private readonly IShooterFactory _shooterFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IGameStateMachine _stateMachine;

        public StartBattleState(IShooterFactory shooterFactory, ILevelDataProvider levelDataProvider, IGameStateMachine stateMachine)
        {
            _shooterFactory = shooterFactory;
            _levelDataProvider = levelDataProvider;
            _stateMachine = stateMachine;
        }
    
        public override void Enter()
        {
            _shooterFactory.CreateShooter(_levelDataProvider.StartPoint);
            _stateMachine.Enter<BattleLoopState>();
        }
    }
}