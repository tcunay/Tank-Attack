using Entitas;

namespace Code.Gameplay.Features.Armaments
{
    public class ArmamentComponents
    {
        [Game] public class Armament : IComponent { }
        [Game] public class Projectile : IComponent { }
    }
}