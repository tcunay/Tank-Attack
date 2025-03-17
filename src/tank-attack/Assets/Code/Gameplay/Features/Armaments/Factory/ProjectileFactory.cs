using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armaments.Setup;
using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticData;
        private readonly IIdentifierService _identifierService;

        public event Action<GameEntity> Created;

        public ProjectileFactory(IInstantiator instantiator, IStaticDataService staticData, IIdentifierService identifierService)
        {
            _instantiator = instantiator;
            _staticData = staticData;
            _identifierService = identifierService;
        }

        public GameEntity CreateBullet(Vector3 at, Vector3 direction, ProjectileSetup setup)
        {
            return CreateEntity.Empty(_identifierService.Next())
                .AddViewPath(AssetPath.BulletPrefabPath)
                .AddWorldPosition(at)
                .AddSpeed(setup.Speed)
                .AddDirection(direction)
                .AddSelfDestructTimer(5)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isMoving = true)
                .With(x => x.isProjectile = true);
        }
    }
}