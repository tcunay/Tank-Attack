using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.View;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Gameplay.Features.Compass.Factory
{
    public class MarkFactory : IMarkFactory
    {
        private readonly IIdentifierService _identifierService;

        public MarkFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        public GameEntity CreateMark()
        {
            return CreateEntity
                .Empty(_identifierService.Next())
                .AddViewPath(AssetPath.EnemyMark)
                .With(x => x.isCompassMark = true);
        }
    }
}