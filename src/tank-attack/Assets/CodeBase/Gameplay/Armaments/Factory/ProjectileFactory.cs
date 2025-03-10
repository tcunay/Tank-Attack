using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Gameplay.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Armaments.Factory
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticData;

        public event Action<GameObject> Created;

        public ProjectileFactory(IInstantiator instantiator, IStaticDataService staticData)
        {
            _instantiator = instantiator;
            _staticData = staticData;
        }

        public GameObject CreateBullet(Vector3 at)
        {
            GameObject bullet =
                _instantiator.InstantiatePrefab(_staticData.BulletPrefab(), at, Quaternion.identity, null);

            Created?.Invoke(bullet);
            return bullet;
        }
    }
}