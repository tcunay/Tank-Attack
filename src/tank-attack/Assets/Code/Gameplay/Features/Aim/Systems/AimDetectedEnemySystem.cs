using Code.Gameplay.Common.PhysicsGame;
using Entitas;

namespace Code.Gameplay.Features.Aim.Systems
{
    public class AimDetectedEnemySystem : IExecuteSystem
    {
        private const float RadiusFactor = 0.0125f;
        
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _aims;
        private readonly IGroup<GameEntity> _cameras;

        public AimDetectedEnemySystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _aims = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Aim,
                    GameMatcher.WorldPosition,
                    GameMatcher.Direction,
                    GameMatcher.LayerMask
                    ));
            
            _cameras = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CameraUnity,
                    GameMatcher.MainCamera
                ));
        }

        public void Execute()
        {
            foreach (GameEntity camera in _cameras)
            foreach (GameEntity aim in _aims)
            {
                float radius = RadiusFactor * camera.CameraUnity.fieldOfView;
                GameEntity hit = _physicsService.SphereCast(aim.WorldPosition, aim.Direction, aim.LayerMask, radius, 100);

                if (hit != null)
                {
                    aim.ReplaceDetectedTargetId(hit.Id);
                }
                else
                {
                    if(aim.hasDetectedTargetId)
                        aim.RemoveDetectedTargetId();
                }
               
            }
        }
    }
}