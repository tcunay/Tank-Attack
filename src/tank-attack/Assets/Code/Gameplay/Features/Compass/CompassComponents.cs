using Code.Gameplay.Features.Compass.View;
using Entitas;

namespace Code.Gameplay.Features.Compass
{
    [Game] public class CompassViewComponent : IComponent { public CompassView Value; }
    [Game] public class CompassMark : IComponent { }
    [Game] public class Marked : IComponent { }
}