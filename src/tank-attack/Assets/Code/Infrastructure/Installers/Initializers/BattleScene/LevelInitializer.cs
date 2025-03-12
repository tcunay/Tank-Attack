using Code.Gameplay.Cameras.Components;
using Code.Gameplay.Cameras.Factory;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Vehicle.Factory;
using Code.Gameplay.Features.Vehicle.Setup;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.GameStates.Battle;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers.Initializers.BattleScene
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Camera _mainCamera;
        
        private IHeroFactory _heroFactory;
        private ILevelDataProvider _levelDataProvider;
        private ICameraFactory _cameraFactory;
        private ICameraProvider _cameraProvider;
        private IVehicleFactory _vehicleFactory;
        private IGameStateMachine _stateMachine;

        //[Inject]
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
            /*GameObject gameObject = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            
            _cameraProvider.SetMainCamera(_cameraFactory.CreateCamera());
            _cameraProvider.MainCamera.GetComponent<CameraFollow>().Setup(gameObject.transform);

            foreach (VehicleSetup setup in _levelDataProvider.MoveSetups)
            {
                _vehicleFactory.CreateVehicle(setup);
            }
            
            _stateMachine.Enter<BattleLoopState>();*/
        }
    }
}