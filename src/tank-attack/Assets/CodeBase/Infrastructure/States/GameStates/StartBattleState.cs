using Code.Gameplay.Levels;
using Code.Gameplay.Levels.Setup;
using CodeBase.Gameplay.Cameras.Components;
using CodeBase.Gameplay.Cameras.Factory;
using CodeBase.Gameplay.Cameras.Provider;
using CodeBase.Gameplay.Hero.Factory;
using CodeBase.Gameplay.Vehicle.Factory;
using CodeBase.Gameplay.Vehicle.Setup;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;
using CodeBase.Meta.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.States.GameStates
{
    public class StartBattleState : SimplePayloadState<LevelConfig>
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IGameStateMachine _stateMachine;
        private readonly IVehicleFactory _vehicleFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly ICameraFactory _cameraFactory;
        private readonly LoadingCurtain _loadingCurtain;

        public StartBattleState(
            IHeroFactory heroFactory,
            ILevelDataProvider levelDataProvider,
            IGameStateMachine stateMachine,
            IVehicleFactory vehicleFactory,
            ICameraProvider cameraProvider,
            ICameraFactory cameraFactory
            )
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
            _stateMachine = stateMachine;
            _vehicleFactory = vehicleFactory;
            _cameraProvider = cameraProvider;
            _cameraFactory = cameraFactory;
        }
    
        public override void Enter(LevelConfig levelConfig)
        {
            GameObject gameObject = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            _cameraProvider.SetMainCamera(_cameraFactory.CreateCamera());
            _cameraProvider.MainCamera.GetComponent<CameraFollow>().Setup(gameObject.transform);

            foreach (VehicleSetup setup in _levelDataProvider.MoveSetups)
            {
                _vehicleFactory.CreateVehicle(setup);
            }
            
            _stateMachine.Enter<BattleLoopState>();
        }
    }
}