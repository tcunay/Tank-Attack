using CodeBase.Gameplay.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Armaments.Factory
{
    public class BulletFactory : IBulletFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticData;

        public BulletFactory(IInstantiator instantiator, IStaticDataService staticData)
        {
            _instantiator = instantiator;
            _staticData = staticData;
        }

        public GameObject CreateBullet(Vector3 at)
        {
            GameObject bullet = _instantiator.InstantiatePrefab(_staticData.BulletPrefab(), at, Quaternion.identity, null);
            GameObject.Destroy(bullet, 15);
            return bullet;
        }
    }
}