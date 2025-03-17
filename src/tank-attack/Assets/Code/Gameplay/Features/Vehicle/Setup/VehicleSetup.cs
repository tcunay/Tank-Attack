using System;

namespace Code.Gameplay.Features.Vehicle.Setup
{
    [Serializable]
    public class VehicleSetup
    {
        public VehicleKind Kind;
        public WayPointsMoveSetup MoveSetup;
    }
}