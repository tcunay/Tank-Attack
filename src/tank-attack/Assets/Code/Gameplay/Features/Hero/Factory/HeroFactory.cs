using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;

        public HeroFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        public GameEntity CreateHero(Vector3 at, Quaternion rotation)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddWorldRotation(rotation.eulerAngles)
                .AddViewPath(AssetPath.HeroPrefabPath)
                .With(x => x.isHero = true);
        }
    }
}