using CodeBase.Gameplay.Stats.Health;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments.Components
{
    public class ProjectileAttack : MonoBehaviour
    {
        public SphereCollider SphereCollider;
        
        private const string HittableLayerName = "Hittable";
        private const float Damage = 1;
        
        private int _layerMask;
        private readonly Collider[] _hits = new Collider[5];

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer(HittableLayerName);
        }

        private void Update()
        {
            int hitCount = Hit();
            
            for (int i = 0; i < hitCount; i++)
            {
                if (_hits[i].transform.parent.TryGetComponent(out IHealth health))
                {
                    Debug.Log("Hit");
                    health.TakeDamage(Damage);
                }
                else
                {
                    Debug.LogError("Need exist Health");
                }
            }

            if (hitCount > 0)
            {
                Destroy(gameObject);
            }
        }
        
        private int Hit() => 
            Physics.OverlapSphereNonAlloc(transform.position, SphereCollider.radius, _hits, _layerMask);
    }
}