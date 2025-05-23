using Entitas;

namespace Code.Gameplay.Features.Lifetime
{
    [Game] public class CurrentHp : IComponent { public float Value; }
    [Game] public class MaxHp : IComponent { public float Value; }
    [Game] public class PrevHp : IComponent { public float Value; }
    [Game] public class TakeDamage : IComponent { public float Value; }
    [Game] public class Dead : IComponent { }
    [Game] public class ProcessingDeath : IComponent { }
}