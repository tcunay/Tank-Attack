using System;
using Code.Gameplay.Armaments.Setup;
using UnityEngine;

namespace Code.Gameplay.Armaments.Models
{
    public class WeaponMagazine : IWeaponMagazine
    {
        private readonly ArmamentSetup _setup;

        public int Count { get; private set; }

        public event Action Changed;

        public WeaponMagazine(ArmamentSetup setup)
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