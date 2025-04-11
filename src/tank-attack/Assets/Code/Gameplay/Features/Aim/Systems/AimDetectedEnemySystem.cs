using Code.Gameplay.Common.PhysicsGame;
using Entitas;

namespace Code.Gameplay.Features.Aim.Systems
{
    public class AimDetectedEnemySystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _aims;

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
        }

        public void Execute()
        {
            foreach (GameEntity aim in _aims)
            {
                GameEntity hit = _physicsService.Raycast(aim.WorldPosition, aim.Direction, aim.LayerMask, 100);

                if (hit is {isEnemy: true})
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