using Code.Gameplay.Features.EnemyHpBar.Systems;
using Code.Gameplay.Features.Lifetime.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Lifetime
{
    public sealed class DamageFeature : Feature
    {
        public DamageFeature(ISystemFactory systems)
        {
            Add(systems.Create<ProcessingTakeDamageSystem>());
            
            Add(systems.Create<UpdateEnemyBarSystem>());
            Add(systems.Create<RotateHpBarTowardsHeroSystem>());
            
            Add(systems.Create<CleanupTakeDamageSystem>());
        }
    }
}