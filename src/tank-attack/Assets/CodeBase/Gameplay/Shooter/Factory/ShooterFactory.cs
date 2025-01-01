using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Shooter.Factory
{
    public class ShooterFactory : IShooterFactory
    {
        private readonly IInstantiator _instantiator;
        private const string ShooterPrefabPath = "Shooter";

        public ShooterFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public GameObject CreateShooter(Vector3 at)
        {
            return _instantiator
                .InstantiatePrefabResource(ShooterPrefabPath, at, Quaternion.identity, null);
        }
    }
}