using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armaments.Setup;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IIdentifierService _identifierService;

        public ProjectileFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateBullet(Vector3 at, Vector3 direction, ProjectileSetup setup)
        {
            return CreateEntity.Empty(_identifierService.Next())
                .AddViewPath(AssetPath.BulletPrefabPath)
                .AddWorldPosition(at)
                .AddRotationSpeed(setup.Speed)
                .AddWorldRotation(Quaternion.LookRotation(direction))
                .AddSpeed(setup.Speed)
                .AddDamage(setup.Damage)
                .AddDirection(direction)
                .AddSelfDestructTimer(10)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isMoving = true)
                .With(x => x.isProjectile = true)
                .AddRadius(setup.ContactRadius)
                .AddTargetsBuffer(new List<int>())
                .AddProcessedTargets(new HashSet<int>())
                .AddLayerMask(CollisionLayer.Hittable.AsMask())
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetsContinuously = true);
        }

        public GameEntity CreateAutoHomingBullet(Vector3 at, Vector3 direction, ProjectileSetup setup, int targetId)
        {
            return CreateBullet(at, direction, setup)
                .AddDetectedTargetId(targetId)
                .With(x => x.isAutoHoming = true);
        }
    }
}