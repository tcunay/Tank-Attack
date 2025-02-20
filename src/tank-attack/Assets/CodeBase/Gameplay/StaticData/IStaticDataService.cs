using CodeBase.Gameplay.Vehicle.Setup;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        UniTask LoadAll();
        GameObject HeroPrefab();
        GameObject BulletPrefab();
        GameObject CameraPrefab();
        VehicleConfig GetVehicleConfig(VehicleKind vehicleKind);
    }
}