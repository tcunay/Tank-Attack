using System;
using CodeBase.Gameplay.Armaments.Components;
using CodeBase.Gameplay.Armaments.Factory;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments.Services
{
    public class ShootService : IShootService
    {
        private readonly IProjectileFactory _projectileFactory;

        public event Action Shooted;

        public ShootService(IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
        }

        public void Shoot(Vector3 at, Vector3 direction)
        {
            Debug.Log("Shoot");
            GameObject gameObject = _projectileFactory.CreateBullet(at);

            gameObject.transform.forward = direction;
            gameObject.GetComponent<ProjectileMove>().MoveDirection = direction;
            
            Shooted?.Invoke();
        }
    }
}