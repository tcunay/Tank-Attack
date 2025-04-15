using Code.Gameplay.Features.Vehicle.Setup;
using Entitas;

namespace Code.Gameplay.Features.Vehicle
{
    public class VehicleComponents
    {
        [Game] public class  VehicleTypeIdComponent : IComponent { public EnemyType Value; }
        [Game] public class  Tank : IComponent { }
        [Game] public class  Helicopter : IComponent { }
        [Game] public class  Dron : IComponent { }
        [Game] public class  BlockPost : IComponent { }
    }
}