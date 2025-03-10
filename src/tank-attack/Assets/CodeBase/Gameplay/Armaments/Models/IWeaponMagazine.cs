using System;

namespace CodeBase.Gameplay.Armaments.Models
{
    public interface IWeaponMagazine
    {
        int Count { get; }
        event Action Changed;
        void Remove(int count);
    }
}