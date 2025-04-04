using System;
using System.Collections.Generic;
using System.Linq;
using Code.DebugEnvironment;
using Code.Gameplay.Features.Vehicle.Setup;
using Code.Gameplay.Levels.Setup;
using Code.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        private GameObject _hero;
        private GameObject _bullet;
        private GameObject _camera;
        private GameObject _enemyMark;
        private Dictionary<VehicleKind ,VehicleConfig> _vehicleConfigs;
        private Dictionary<int, LevelConfig> _levels;
        private AssetReference _gameOverSceneReference;
        private DebugEnvironmentSettings _debugEnvironmentSettings;

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async UniTask LoadAll()
        {
            await UniTask.WhenAll(
                LoadHeroPrefab(),
                LoadBulletPrefab(),
                LoadCameraPrefab(),
                LoadVehicles(),
                LoadLevels(),
                LoadDebugEnvironmentSettings(),
                LoadEnemyMarkPrefab()
            );
        }
        
        public GameObject HeroPrefab()
        {
            return _hero;
        }

        public GameObject BulletPrefab()
        {
            return _bullet;
        }

        public GameObject CameraPrefab()
        {
            return _camera;
        }
        
        public GameObject EnemyMarkPrefab()
        {
            return _enemyMark;
        }

        public VehicleConfig GetVehicleConfig(VehicleKind vehicleKind)
        {
            if (_vehicleConfigs.TryGetValue(vehicleKind, out VehicleConfig config))
            {
                return config;
            }
            
            throw new Exception($"Vehicle config for {vehicleKind} was not found");
        }

        public LevelConfig GetLevelConfig(int levelNumber)
        {
            if (_levels.TryGetValue(levelNumber, out LevelConfig config))
            {
                return config;
            }
            
            throw new Exception($"Level config for {levelNumber} was not found");
        }

        public AssetReference GameOverSceneReference()
        {
            return _gameOverSceneReference;
        }

        public DebugEnvironmentSettings DebugEnvironmentSettings()
        {
            return _debugEnvironmentSettings;
        }

        private async UniTask LoadHeroPrefab()
        {
            _hero = await Load(AssetPath.HeroPrefabPath);
        }
        
        private async UniTask LoadEnemyMarkPrefab()
        {
            _enemyMark = await Load(AssetPath.EnemyMark);
        }
        
        private async UniTask LoadBulletPrefab()
        {
            _bullet = await Load(AssetPath.BulletPrefabPath);
        }
        
        private async UniTask LoadCameraPrefab()
        {
            _camera = await Load(AssetPath.CameraPrefabPath);
        }
        
        private async UniTask LoadDebugEnvironmentSettings()
        {
            _debugEnvironmentSettings =
                await _assetProvider.LoadAsset<DebugEnvironmentSettings>(AssetPath.DebugEnvironmentSettings);
        }
        
        private async UniTask LoadVehicles()
        {
            IList<VehicleConfig> vehiclesList = await _assetProvider.LoadAssets<VehicleConfig>(AssetPath.Vehicles);
            _vehicleConfigs = vehiclesList.ToDictionary(x => x.Kind);
        }
        
        private async UniTask LoadLevels()
        {
            IList<LevelConfig> levels = await _assetProvider.LoadAssets<LevelConfig>(AssetPath.LevelConfig);
            _levels = levels.ToDictionary(x => x.LevelNumber);
        }

        private async UniTask<GameObject> Load(string path)
        {
            return await _assetProvider.LoadAsset(path);
        }
    }
}