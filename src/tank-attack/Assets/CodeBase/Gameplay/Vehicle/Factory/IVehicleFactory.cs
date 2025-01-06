using CodeBase.Gameplay.Vehicle.Setup;
using UnityEngine;

namespace CodeBase.Gameplay.Vehicle.Factory
{
    public interface IVehicleFactory
    {
        GameObject CreateVehicle(VehicleSetup setup);
    }
}