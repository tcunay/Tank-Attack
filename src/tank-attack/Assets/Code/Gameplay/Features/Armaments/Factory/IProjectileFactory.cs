using System;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public interface IProjectileFactory
    {
        event Action<GameObject> Created;
        GameObject CreateBullet(Vector3 at);
    }
}