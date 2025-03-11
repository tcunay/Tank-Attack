using System;

namespace Code.Gameplay.Armaments.Services
{
    public interface IBulletsLifeCycleService
    {
        int LiveBulletsCount { get; }
        event Action CountChanged;
    }
}