using CodeBase.Gameplay.Vehicle.Setup;
using CodeBase.Gameplay.Vehicle.View;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Vehicle.Factory
{
    public class VehicleFactory : IVehicleFactory
    {
        private readonly IInstantiator _instantiator;

        public VehicleFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public GameObject CreateVehicle(VehicleSetup setup)
        {
            GameObject vehicle = _instantiator.InstantiatePrefab(setup.Prefab);
            
            vehicle
                .GetComponent<WayPointsMove>()
                .Setup(setup.MoveSetup);

            return vehicle;
        }
    }
}