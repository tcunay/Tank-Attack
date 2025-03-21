using Code.Gameplay.Features.Armaments.Systems;
using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
    public class CollectTargetsFeature : Feature
    {
        public CollectTargetsFeature(ISystemFactory systems)
        {
            Add(systems.Create<CastForTargetsSystem>());
            Add(systems.Create<MarkReachedSystem>());
            
            Add(systems.Create<TakeDamageWhenProjectileIsReachedSystem>());
            Add(systems.Create<ProjectileMarkDestructedWhenReachedSystem>());

            Add(systems.Create<CleanupTargetBufferSystem>());
        }
    }
}