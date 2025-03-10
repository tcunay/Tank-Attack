using System;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments.Factory
{
    public interface IProjectileFactory
    {
        event Action<GameObject> Created;
        GameObject CreateBullet(Vector3 at);
    }
}