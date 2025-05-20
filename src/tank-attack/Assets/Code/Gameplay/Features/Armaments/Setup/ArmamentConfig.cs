using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Setup
{
    [CreateAssetMenu(fileName = "armamentConfig", menuName = "TankAttack/Armament Config")]
    public class ArmamentConfig : ScriptableObject
    {
        public ProjectileSetup ProjectileSetup;
    }
}