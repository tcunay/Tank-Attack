using Code.DebugEnvironment;
using Code.Gameplay.Features.Vehicle.Setup;
using Code.Gameplay.Levels.Setup;
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
        VehicleConfig GetVehicleConfig(EnemyType vehicleKind);
        LevelConfig GetLevelConfig(int levelNumber);
        AssetReference GameOverSceneReference();
        DebugEnvironmentSettings DebugEnvironmentSettings();
        GameObject EnemyMarkPrefab();
    }
}