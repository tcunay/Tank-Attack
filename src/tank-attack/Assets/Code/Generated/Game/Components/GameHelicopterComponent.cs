//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHelicopter;

    public static Entitas.IMatcher<GameEntity> Helicopter {
        get {
            if (_matcherHelicopter == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Helicopter);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHelicopter = matcher;
            }

            return _matcherHelicopter;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Gameplay.Features.Vehicle.VehicleComponents.Helicopter helicopterComponent = new Code.Gameplay.Features.Vehicle.VehicleComponents.Helicopter();

    public bool isHelicopter {
        get { return HasComponent(GameComponentsLookup.Helicopter); }
        set {
            if (value != isHelicopter) {
                var index = GameComponentsLookup.Helicopter;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : helicopterComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
