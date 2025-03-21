using Code.Gameplay.Features.Enemies.Systems;
using Code.Infrastructure.Systems;

public sealed class EnemyFeature : Feature
{
    public EnemyFeature(ISystemFactory systems)
    {
        Add(systems.Create<EnemyDeathSystem>());
        
        Add(systems.Create<FinalizeEnemyDeathProcessingSystem>());
    }
}