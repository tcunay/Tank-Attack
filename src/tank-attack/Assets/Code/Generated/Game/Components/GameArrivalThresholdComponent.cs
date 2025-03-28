//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherArrivalThreshold;

    public static Entitas.IMatcher<GameEntity> ArrivalThreshold {
        get {
            if (_matcherArrivalThreshold == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ArrivalThreshold);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherArrivalThreshold = matcher;
            }

            return _matcherArrivalThreshold;
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

    public Code.Gameplay.Features.Movement.ArrivalThreshold arrivalThreshold { get { return (Code.Gameplay.Features.Movement.ArrivalThreshold)GetComponent(GameComponentsLookup.ArrivalThreshold); } }
    public float ArrivalThreshold { get { return arrivalThreshold.Value; } }
    public bool hasArrivalThreshold { get { return HasComponent(GameComponentsLookup.ArrivalThreshold); } }

    public GameEntity AddArrivalThreshold(float newValue) {
        var index = GameComponentsLookup.ArrivalThreshold;
        var component = (Code.Gameplay.Features.Movement.ArrivalThreshold)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.ArrivalThreshold));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceArrivalThreshold(float newValue) {
        var index = GameComponentsLookup.ArrivalThreshold;
        var component = (Code.Gameplay.Features.Movement.ArrivalThreshold)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.ArrivalThreshold));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveArrivalThreshold() {
        RemoveComponent(GameComponentsLookup.ArrivalThreshold);
        return this;
    }
}
