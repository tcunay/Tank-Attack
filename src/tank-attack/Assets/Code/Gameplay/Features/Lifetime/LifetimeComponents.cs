using Entitas;

namespace Code.Gameplay.Features.Lifetime
{
    [Game] public class CurrentHP : IComponent { public float Value; }
    [Game] public class Dead : IComponent { }
    [Game] public class ProcessingDeath : IComponent { }
}