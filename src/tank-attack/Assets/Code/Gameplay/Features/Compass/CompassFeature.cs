using Code.Gameplay.Features.Camera.Systems;
using Code.Gameplay.Features.Compass.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Compass
{
    public sealed class CompassFeature : Feature
    {
        public CompassFeature(ISystemFactory systems)
        {
            Add(systems.Create<RemoveMarkWithoutTargetSystem>());
            
            Add(systems.Create<CreateMarkToEnemySystem>());
            Add(systems.Create<MoveMarksSystem>());
        }
    }
}