using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Levels;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly ILevelDataProvider _levelDataProvider;

        public HeroFactory(IIdentifierService identifierService, ILevelDataProvider levelDataProvider)
        {
            _identifierService = identifierService;
            _levelDataProvider = levelDataProvider;
        }
        
        public GameEntity CreateHero(Vector3 at, Quaternion rotation)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddMaxBulletsCount(_levelDataProvider.LevelConfig.ArmamentSetup.Count)
                .AddCurrentBulletsCount(_levelDataProvider.LevelConfig.ArmamentSetup.Count)
                .AddWorldPosition(at)
                .AddWorldRotation(rotation)
                .AddViewPath(AssetPath.HeroPrefabPath)
                .With(x => x.isHero = true);
        }
    }
}