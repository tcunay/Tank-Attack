using Code.Gameplay.Vehicle.Setup;
using UnityEngine;

namespace Code.Gameplay.Vehicle.Factory
{
    public interface IVehicleFactory
    {
        GameObject CreateVehicle(VehicleSetup setup);
    }
}