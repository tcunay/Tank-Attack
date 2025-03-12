using Code.Gameplay.Features.Vehicle.Setup;
using UnityEngine;

namespace Code.Gameplay.Features.Vehicle.Factory
{
    public interface IVehicleFactory
    {
        GameObject CreateVehicle(VehicleSetup setup);
    }
}