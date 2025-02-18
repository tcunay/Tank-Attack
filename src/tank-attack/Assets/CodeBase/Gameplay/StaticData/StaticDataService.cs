using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Vehicle.Setup;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private GameObject _hero;
        private GameObject _bullet;
        private GameObject _camera;
        private Dictionary<VehicleKind ,VehicleConfig> _vehicleConfigs;

        private const string HeroPrefabPath = "Hero";
        private const string BulletPrefabPath = "Bullet";
        private const string CameraPrefabPath = "Camera";

        public void LoadAll()
        {
            LoadHeroPrefab();
            LoadBulletPrefab();
            LoadCameraPrefab();
            LoadVehicles();
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

        private void LoadHeroPrefab()
        {
            _hero = Load<GameObject>(HeroPrefabPath);
        }
        
        private void LoadBulletPrefab()
        {
            _bullet = Load<GameObject>(BulletPrefabPath);
        }
        
        private void LoadCameraPrefab()
        {
            _camera = Load<GameObject>(CameraPrefabPath);
        }
        
        private void LoadVehicles()
        {
            _vehicleConfigs = Resources
                    .LoadAll<VehicleConfig>("Configs/Vehicles")
                    .ToDictionary(x => x.Kind);
        }

        private T Load<T>(string path) where T : Object
        {
            var loaded = Resources.Load<T>(path);

            if (loaded == null)
            {
                Debug.LogError($"Not Found to path {path}");
            }

            return loaded;
        }
    }
}