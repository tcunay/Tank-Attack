using System;
using UnityEngine;

namespace Code.Gameplay.Armaments.Factory
{
    public interface IProjectileFactory
    {
        event Action<GameObject> Created;
        GameObject CreateBullet(Vector3 at);
    }
}