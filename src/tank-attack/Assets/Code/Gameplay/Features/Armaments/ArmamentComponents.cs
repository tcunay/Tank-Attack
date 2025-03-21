using Entitas;
using TMPro;

namespace Code.Gameplay.Features.Armaments
{
    public class ArmamentComponents
    {
        [Game] public class Armament : IComponent { }
        [Game] public class Projectile : IComponent { }
        [Game] public class MaxBulletsCount : IComponent { public float Value; }
        [Game] public class CurrentBulletsCount : IComponent { public float Value; }
        [Game] public class BulletCounter : IComponent { public TMP_Text Value; }
    }
}