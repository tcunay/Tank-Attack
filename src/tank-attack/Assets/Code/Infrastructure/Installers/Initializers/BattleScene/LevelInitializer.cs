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
        [SerializeField] private Transform _heroPoint;
        
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }
        
        public void Initialize()
        {
            _levelDataProvider.SetStartPoint(_heroPoint);
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