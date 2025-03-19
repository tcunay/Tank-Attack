using Code.Gameplay.Features.Vehicle.Setup;
using Entitas;

namespace Code.Gameplay.Features.Vehicle
{
    public class VehicleComponents
    {
        [Game] public class  VehicleTypeIdComponent : IComponent { public VehicleKind Value; }
        [Game] public class  Tank : IComponent { }
        [Game] public class  Helicopter : IComponent { }
    }
}