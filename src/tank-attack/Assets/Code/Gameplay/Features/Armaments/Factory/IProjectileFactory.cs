using System;
using Code.Gameplay.Features.Armaments.Setup;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public interface IProjectileFactory
    {
        GameEntity CreateBullet(Vector3 at, Vector3 direction, ProjectileSetup setup);
        GameEntity CreateAutoHomingBullet(Vector3 at, Vector3 direction, ProjectileSetup setup, int targetId);
    }
}