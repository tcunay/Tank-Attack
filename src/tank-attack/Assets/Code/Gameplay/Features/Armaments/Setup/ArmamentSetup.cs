using System;

namespace Code.Gameplay.Features.Armaments.Setup
{
    [Serializable]
    public class ArmamentSetup
    {
        public int Count;
        public ArmamentConfig Config;
    }

    [Serializable]
    public class ProjectileSetup
    {
        public float Speed;
        public float ContactRadius;
        public float Damage;
    }
    
}