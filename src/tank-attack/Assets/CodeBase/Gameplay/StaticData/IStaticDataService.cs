using CodeBase.Gameplay.Vehicle.Setup;
using UnityEngine;

namespace CodeBase.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();
        GameObject HeroPrefab();
        GameObject BulletPrefab();
        GameObject CameraPrefab();
        VehicleConfig GetVehicleConfig(VehicleKind vehicleKind);
    }
}