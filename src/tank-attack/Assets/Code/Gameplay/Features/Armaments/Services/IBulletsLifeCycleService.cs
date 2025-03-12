using System;

namespace Code.Gameplay.Features.Armaments.Services
{
    public interface IBulletsLifeCycleService
    {
        int LiveBulletsCount { get; }
        event Action CountChanged;
    }
}