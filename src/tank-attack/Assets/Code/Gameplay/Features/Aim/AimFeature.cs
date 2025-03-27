using Code.Gameplay.Features.Aim.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Aim
{
    public sealed class AimFeature : Feature
    {
        public AimFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitAimSystem>());
            
            Add(systems.Create<SetAimDirectionByHeroSystem>());
            
            Add(systems.Create<AimDetectedEnemySystem>());
            
            Add(systems.Create<AddDetectingTimeToAutoHomingAim>());
            Add(systems.Create<SetAimTimerText>());
            
            Add(systems.Create<EnableAutoHomingBulletByDetectingTimeSystem>());
        }
    }
}