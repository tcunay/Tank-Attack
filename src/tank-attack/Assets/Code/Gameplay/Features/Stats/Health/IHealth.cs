namespace Code.Gameplay.Features.Stats.Health
{
    public interface IHealth
    {
        float Current { get; }
        void TakeDamage(float damage);
    }
}