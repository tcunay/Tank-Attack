using System;
using System.Collections;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Infrastructure.Common;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Armaments.Services
{
    public class BulletsLifeCycleService : IBulletsLifeCycleService, IInitializable
    {
        private readonly IProjectileFactory _factory;
        private readonly ICoroutineRunner _coroutineRunner;
        
        public BulletsLifeCycleService(IProjectileFactory factory, ICoroutineRunner coroutineRunner)
        {
            _factory = factory;
            _coroutineRunner = coroutineRunner;
        }
        
        public event Action CountChanged;
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