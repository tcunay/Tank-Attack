using CodeBase.Gameplay.Armaments.Factory;
using CodeBase.Gameplay.Armaments.View;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments.Services
{
    public class ShootService : IShootService
    {
        private readonly IBulletFactory _bulletFactory;

        public ShootService(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public void Shoot(Vector3 at, Vector3 direction)
        {
            Debug.Log("Shoot");
            GameObject gameObject = _bulletFactory.CreateBullet(at);

            gameObject.transform.forward = direction;
            gameObject.GetComponent<BulletMove>().MoveDirection = direction;
        }
    }
}