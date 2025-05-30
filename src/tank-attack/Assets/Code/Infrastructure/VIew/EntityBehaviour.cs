using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;

        public GameEntity Entity => _entity;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            RegisterComponents();
            Vector3 directionToCenter = RegisterColliders();
            
            RegisterDirectionToCenter(directionToCenter);
        }

        public void ReleaseEntity()
        {
            UnRegisterComponents();
            UnregisterColliders();
            
            UnRegisterDirectionToCenter();
            
            _entity.Release(this);
            _entity = null;
        }

        private Vector3 RegisterColliders()
        {
            Collider[] colliders = GetComponentsInChildren<Collider>(includeInactive: true);
            Vector3 centersSum = Vector3.zero;
            
            foreach (Collider collider in colliders)
            {
                _collisionRegistry.Register(collider.GetInstanceID(), _entity);
                centersSum += collider.bounds.center;
            }

            Vector3 center = centersSum / colliders.Length;
            Vector3 directionToCenter = transform.position - center;

            return directionToCenter;
        }

        private void UnregisterColliders()
        {
            foreach (Collider collider in GetComponentsInChildren<Collider>(includeInactive: true))
                _collisionRegistry.Unregister(collider.GetInstanceID());
        }

        private void RegisterComponents()
        {
            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.RegisterComponents();
        }

        private void UnRegisterComponents()
        {
            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.UnRegisterComponents();
        }
        
        private void RegisterDirectionToCenter(Vector3 directionToCenter)
        {
            Entity.AddDirectionToCenter(directionToCenter);
        }
        
        private void UnRegisterDirectionToCenter()
        {
            if (Entity.hasDirectionToCenter)
            {
                Entity.RemoveDirectionToCenter();
            }
        }
    }
}