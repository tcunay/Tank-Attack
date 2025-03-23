using System.Collections.Generic;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class DrawDebugCollidersSystem :  ReactiveSystem<GameEntity>
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IDrawColliderService _drawColliderService;

        public DrawDebugCollidersSystem(GameContext game, IStaticDataService staticDataService, IDrawColliderService drawColliderService) : base(game)
        {
            _staticDataService = staticDataService;
            _drawColliderService = drawColliderService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.DebugCollider.Added());
        
        protected override bool Filter(GameEntity entity) => entity.hasDebugCollider && _staticDataService.DebugEnvironmentSettings().IsDebugEnvironment;
        
        protected override void Execute(List<GameEntity> colliders)
        {
            foreach (GameEntity collider in colliders)
            {
                _drawColliderService.Draw(collider.DebugCollider);
            }
        }
    }
}