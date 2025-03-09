using CodeBase.Gameplay.Stats.Health;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments.Components
{
    public class ProjectileAttack : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;
        
        private const string HittableLayerName = "Hittable";
        private const float Damage = 1;
        
        private readonly Collider[] _hits = new Collider[5];
        private int _layerMask;

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer(HittableLayerName);
            _collider.enabled = false;
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
            Physics.OverlapSphereNonAlloc(transform.position, _collider.radius, _hits, _layerMask);
    }
}