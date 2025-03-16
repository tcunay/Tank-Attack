using System;

namespace Code.Gameplay.Features.Armaments.Setup
{
    [Serializable]
    public class ArmamentSetup
    {
        public int Count;
        public ProjectileSetup ProjectileSetup;
    }

    [Serializable]
    public class ProjectileSetup
    {
        public float Speed;
    }
    
}