using System;

namespace CodeBase.Gameplay.Armaments.Services
{
    public interface IBulletsLifeCycleService
    {
        int LiveBulletsCount { get; }
        event Action CountChanged;
    }
}