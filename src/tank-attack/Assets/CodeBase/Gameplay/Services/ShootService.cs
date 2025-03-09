using CodeBase.Gameplay.Armaments.Components;
using CodeBase.Gameplay.Armaments.Factory;
using CodeBase.Gameplay.Armaments.Models;
using CodeBase.Gameplay.Armaments.Services;
using UnityEngine;

namespace CodeBase.Gameplay.Services
{
    public class ShootService : IShootService
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly IBulletMagazine _bulletMagazine;
        
        public ShootService(IProjectileFactory projectileFactory, IBulletMagazine bulletMagazine)
        {
            _projectileFactory = projectileFactory;
            _bulletMagazine = bulletMagazine;
        }

        public void Shoot(Vector3 at, Vector3 direction)
        {
            Debug.Log("Shoot");
            GameObject gameObject = _projectileFactory.CreateBullet(at);

            gameObject.GetComponent<ProjectileMove>().MoveDirection = direction;
            
            _bulletMagazine.Remove(1);
        }
    }
}