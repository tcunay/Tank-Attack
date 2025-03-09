using System;

namespace CodeBase.Gameplay.Armaments.Models
{
    public interface IBulletMagazine
    {
        int Count { get; }
        event Action Changed;
        void Remove(int count);
    }
}