using Code.Gameplay.Armaments.Components;
using Code.Gameplay.Armaments.Factory;
using Code.Gameplay.Armaments.Models;
using UnityEngine;

namespace Code.Gameplay.Services
{
    public class ShootService : IShootService
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly IWeaponMagazine _bulletMagazine;
        
        public ShootService(IProjectileFactory projectileFactory, IWeaponMagazine bulletMagazine)
        {
            _projectileFactory = projectileFactory;
            _bulletMagazine = bulletMagazine;
        }

        public void Shoot(Vector3 at, Vector3 direction)
        {
            Debug.Log("Shoot");

            if (_bulletMagazine.Count <= 0)
            {
                return;
            }
            
            GameObject gameObject = _projectileFactory.CreateBullet(at);

            gameObject.GetComponent<ProjectileMove>().MoveDirection = direction;
            
            _bulletMagazine.Remove(1);
        }
    }
}