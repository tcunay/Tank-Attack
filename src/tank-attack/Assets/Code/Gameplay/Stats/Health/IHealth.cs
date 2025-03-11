namespace Code.Gameplay.Stats.Health
{
    public interface IHealth
    {
        float Current { get; }
        void TakeDamage(float damage);
    }
}