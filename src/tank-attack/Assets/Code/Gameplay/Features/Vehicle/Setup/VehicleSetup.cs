using System;

namespace Code.Gameplay.Features.Vehicle.Setup
{
    [Serializable]
    public class VehicleSetup
    {
        public EnemyType Kind;
        public float MaxHp = 1;
        public WayPointsMoveSetup MoveSetup;
    }
}