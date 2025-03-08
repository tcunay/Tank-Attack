using System;
using CodeBase.Gameplay.Armaments.Setup;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments.Services
{
    public class BulletMagazine : IBulletMagazine, IDisposable
    {
        private readonly ArmamentSetup _setup;
        private readonly IShootService _shootService;

        public int Count { get; private set; }

        public event Action Changed;

        public BulletMagazine(ArmamentSetup setup, IShootService shootService)
        {
            _setup = setup;
            _shootService = shootService;

            Count = _setup.Count;

            _shootService.Shooted += OnShoted;
        }
        
        public void Dispose()
        {
            Debug.Log("DISPOSE");
            _shootService.Shooted -= OnShoted;
        }

        private void OnShoted()
        {
            Remove(1);
        }

        public void Remove(int count)
        {
            Debug.Assert(Count >= count);
            
            Count -= count;
            Changed?.Invoke();
        }
    }
}