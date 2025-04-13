using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<DirectionalDeltaMoveSystem>());
            Add(systems.Create<SetRotationByDirection>());
            
            Add(systems.Create<SetHelicopterXAngleSystem>());
            Add(systems.Create<SetDronAngleSystem>());
            
            Add(systems.Create<UpdateTransformPositionSystem>());
            Add(systems.Create<UpdateTransformRotationSystem>());
            
            Add(systems.Create<WayPointsMoveSystem>());
        }
    }
}