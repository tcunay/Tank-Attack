using Code.Gameplay.Features.Vehicle.Components;
using Code.Gameplay.Features.Vehicle.Setup;
using Code.Gameplay.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Vehicle.Factory
{
    public class VehicleFactory : IVehicleFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticDataService;

        public VehicleFactory(IInstantiator instantiator, IStaticDataService staticDataService)
        {
            _instantiator = instantiator;
            _staticDataService = staticDataService;
        }
        
        public GameObject CreateVehicle(VehicleSetup setup)
        {
            GameObject vehicle = _instantiator.InstantiatePrefab(_staticDataService.GetVehicleConfig(setup.Kind).Prefab);
            
            vehicle
                .GetComponent<WayPointsMove>()
                .Setup(setup.MoveSetup);

            return vehicle;
        }
    }
}