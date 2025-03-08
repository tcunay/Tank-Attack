using Code.Gameplay.Levels;
using CodeBase.Gameplay.Cameras.Components;
using CodeBase.Gameplay.Cameras.Factory;
using CodeBase.Gameplay.Cameras.Provider;
using CodeBase.Gameplay.Hero.Factory;
using CodeBase.Gameplay.Vehicle.Factory;
using CodeBase.Gameplay.Vehicle.Setup;
using CodeBase.Infrastructure.States.GameStates;
using CodeBase.Infrastructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers.Initializers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        private IHeroFactory _heroFactory;
        private ILevelDataProvider _levelDataProvider;
        private ICameraFactory _cameraFactory;
        private ICameraProvider _cameraProvider;
        private IVehicleFactory _vehicleFactory;
        private IGameStateMachine _stateMachine;

        [Inject]
        private void Construct(
            IHeroFactory heroFactory,
            ILevelDataProvider levelDataProvider,
            ICameraFactory cameraFactory,
            IVehicleFactory vehicleFactory,
            IGameStateMachine stateMachine,
            ICameraProvider cameraProvider
            )
        {
            _stateMachine = stateMachine;
            _vehicleFactory = vehicleFactory;
            _cameraProvider = cameraProvider;
            _cameraFactory = cameraFactory;
            _levelDataProvider = levelDataProvider;
            _heroFactory = heroFactory;
        }
        
        public void Initialize()
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