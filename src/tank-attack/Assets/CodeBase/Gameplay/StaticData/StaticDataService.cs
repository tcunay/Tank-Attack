using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Vehicle.Setup;
using CodeBase.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        private GameObject _hero;
        private GameObject _bullet;
        private GameObject _camera;
        private Dictionary<VehicleKind ,VehicleConfig> _vehicleConfigs;

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
                LoadVehicles()
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

        public VehicleConfig GetVehicleConfig(VehicleKind vehicleKind)
        {
            if (_vehicleConfigs.TryGetValue(vehicleKind, out VehicleConfig config))
            {
                return config;
            }
            
            throw new Exception($"Vehicle config for {vehicleKind} was not found");
        }

        private async UniTask LoadHeroPrefab()
        {
            _hero = await Load(AssetPath.HeroPrefabPath);
        }
        
        private async UniTask LoadBulletPrefab()
        {
            _bullet = await Load(AssetPath.BulletPrefabPath);
        }
        
        private async UniTask LoadCameraPrefab()
        {
            _camera = await Load(AssetPath.CameraPrefabPath);
        }
        
        private async UniTask LoadVehicles()
        {
            IList<VehicleConfig> vehiclesList = await _assetProvider.LoadAssets<VehicleConfig>("Vehicles");
            _vehicleConfigs = vehiclesList.ToDictionary(x => x.Kind);
        }

        private async UniTask<GameObject> Load(string path)
        {
            return await _assetProvider.LoadAsset(path);
        }
    }
}