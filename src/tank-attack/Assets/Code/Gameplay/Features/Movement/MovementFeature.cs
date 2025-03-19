using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Entitas;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : UniFeature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitPositionByPhysicsEntitySystem>());
            
            Add(systems.Create<DirectionalDeltaMoveSystem>());
            
            Add(systems.Create<AddRigidbodyForceByDirection>());
            Add(systems.Create<MoveRotationRigidbodyByDirection>());
            Add(systems.Create<UpdateWorldPositionToPhysicalMovers>());
            Add(systems.Create<UpdateRotationToPhysicalMovers>());
            
            Add(systems.Create<UpdateTransformPositionSystem>());
            Add(systems.Create<UpdateTransformRotationSystem>());
            
            Add(systems.Create<WayPointsMoveSystem>());
        }
    }
}