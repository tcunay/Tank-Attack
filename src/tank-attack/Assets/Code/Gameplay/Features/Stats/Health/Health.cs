using UnityEngine;

namespace Code.Gameplay.Features.Stats.Health
{
    public class Health : MonoBehaviour, IHealth
    {
        public float Current { get; private set; } = 3;

        public void TakeDamage(float damage)
        {
            Current = Mathf.Max(0, Current - damage);
            Debug.Log("Health = " + Current);

            if (Current <= 0)
            {
                Debug.Log("DEAD");
                Destroy(gameObject);
            }
        }
    }
}