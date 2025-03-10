using System;
using System.Collections;
using CodeBase.Gameplay.Armaments.Factory;
using CodeBase.Infrastructure.Common;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Armaments.Services
{
    public class BulletsLifeCycleService : IBulletsLifeCycleService, IInitializable
    {
        private readonly IProjectileFactory _factory;
        private readonly ICoroutineRunner _coroutineRunner;

        public event Action CountChanged;

        public BulletsLifeCycleService(IProjectileFactory factory, ICoroutineRunner coroutineRunner)
        {
            _factory = factory;
            _coroutineRunner = coroutineRunner;
        }
        
        public int LiveBulletsCount { get; private set; }
        
        public void Initialize()
        {
            _factory.Created += BulletCreated;
        }

        private void BulletCreated(GameObject bullet)
        {
            _coroutineRunner.StartCoroutine(EnableDestroyProcessForBullet(bullet));
        }

        private IEnumerator EnableDestroyProcessForBullet(GameObject bullet)
        {
            SetBulletsCount(LiveBulletsCount + 1);

            yield return new WaitForSeconds(5f);
            
            GameObject.Destroy(bullet);
            
            SetBulletsCount(LiveBulletsCount - 1);
        }

        private void SetBulletsCount(int count)
        {
            Debug.Log($"Count = {count}");
            LiveBulletsCount = count;
            CountChanged?.Invoke();
        }
    }
}