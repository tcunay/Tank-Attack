using UnityEngine;

namespace CodeBase.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private GameObject _hero;
        private GameObject _bullet;
        private GameObject _camera;

        private const string HeroPrefabPath = "Hero";
        private const string BulletPrefabPath = "Bullet";
        private const string CameraPrefabPath = "Camera";

        public void LoadAll()
        {
            LoadHeroPrefab();
            LoadBulletPrefab();
            LoadCameraPrefab();
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