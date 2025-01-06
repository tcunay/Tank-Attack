using Code.Gameplay.Levels;
using CodeBase.Gameplay.Hero.Factory;
using CodeBase.Gameplay.Vehicle.Factory;
using CodeBase.Gameplay.Vehicle.Setup;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;

namespace CodeBase.Infrastructure.States.GameStates
{
    public class StartBattleState : SimpleState
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IGameStateMachine _stateMachine;
        private readonly IVehicleFactory _vehicleFactory;

        public StartBattleState(
            IHeroFactory heroFactory,
            ILevelDataProvider levelDataProvider,
            IGameStateMachine stateMachine,
            IVehicleFactory vehicleFactory
            )
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
            _stateMachine = stateMachine;
            _vehicleFactory = vehicleFactory;
        }
    
        public override void Enter()
        {
            _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            
            foreach (VehicleSetup setup in _levelDataProvider.MoveSetups)
            {
                _vehicleFactory.CreateVehicle(setup);
            }
            
            _stateMachine.Enter<BattleLoopState>();
        }
    }
}