using Code.Gameplay.Features.EndLevel.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.EndLevel
{
    public sealed class EndLevelFeature : Feature
    {
        public EndLevelFeature(ISystemFactory systems)
        {
            Add(systems.Create<WinLevelWhenKillAllEnemySystem>());
            Add(systems.Create<GameOverOnOutOfBulletsSystem>());

        }
    }
}