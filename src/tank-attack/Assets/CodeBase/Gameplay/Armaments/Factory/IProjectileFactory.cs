using UnityEngine;

namespace CodeBase.Gameplay.Armaments.Factory
{
    public interface IProjectileFactory
    {
        GameObject CreateBullet(Vector3 at);
    }
}