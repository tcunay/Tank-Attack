using System;
using CodeBase.Gameplay.Armaments.Services;
using CodeBase.Gameplay.Armaments.Setup;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments.Models
{
    public class BulletMagazine : IBulletMagazine
    {
        private readonly ArmamentSetup _setup;

        public int Count { get; private set; }

        public event Action Changed;

        public BulletMagazine(ArmamentSetup setup)
        {
            _setup = setup;

            Count = _setup.Count;
        }

        public void Remove(int count)
        {
            Debug.Assert(Count >= count);
            
            Count -= count;
            Changed?.Invoke();
        }
    }
}