using Code.Gameplay.Features.Armaments.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Armaments
{
    public sealed class ArmamentsFeature : Feature
    {
        public ArmamentsFeature(ISystemFactory systems)
        {
            Add(systems.Create<ShootByInputSystem>());
            
            Add(systems.Create<SetDirectionByAutoHomingProjectile>());
            
            Add(systems.Create<DecreaseBulletCountSystem>());
            
            Add(systems.Create<BulletCounterSystem>());
        }
    }
}