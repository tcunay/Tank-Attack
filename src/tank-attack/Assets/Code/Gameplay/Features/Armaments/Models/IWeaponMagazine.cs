using System;

namespace Code.Gameplay.Features.Armaments.Models
{
    public interface IWeaponMagazine
    {
        int Count { get; }
        event Action Changed;
        void Remove(int count);
    }
}