using Code.Gameplay.Levels.Setup;
using Code.Gameplay.Vehicle.Setup;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        UniTask LoadAll();
        GameObject HeroPrefab();
        GameObject BulletPrefab();
        GameObject CameraPrefab();
        VehicleConfig GetVehicleConfig(VehicleKind vehicleKind);
        LevelConfig GetLevelConfig(int levelNumber);
        AssetReference GameOverSceneReference();
    }
}