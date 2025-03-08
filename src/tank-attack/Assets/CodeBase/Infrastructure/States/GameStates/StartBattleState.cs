using Code.Gameplay.Levels;
using CodeBase.Gameplay.Armaments.Services;
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
    public class StartBattleState : SimpleState
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IGameStateMachine _stateMachine;
        private readonly IVehicleFactory _vehicleFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly ICameraFactory _cameraFactory;
        private readonly IBulletMagazine _bulletMagazine;
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
    
        public override void Enter()
        {
            
        }
    }
}