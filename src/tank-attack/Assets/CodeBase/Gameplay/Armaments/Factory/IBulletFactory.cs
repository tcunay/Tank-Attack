using UnityEngine;

namespace CodeBase.Gameplay.Armaments.Factory
{
    public interface IBulletFactory
    {
        GameObject CreateBullet(Vector3 at);
    }
}