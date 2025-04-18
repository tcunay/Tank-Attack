//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWayPointsMoveIndex;

    public static Entitas.IMatcher<GameEntity> WayPointsMoveIndex {
        get {
            if (_matcherWayPointsMoveIndex == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WayPointsMoveIndex);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWayPointsMoveIndex = matcher;
            }

            return _matcherWayPointsMoveIndex;
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

    public Code.Gameplay.Features.Movement.WayPointsMoveIndex wayPointsMoveIndex { get { return (Code.Gameplay.Features.Movement.WayPointsMoveIndex)GetComponent(GameComponentsLookup.WayPointsMoveIndex); } }
    public int WayPointsMoveIndex { get { return wayPointsMoveIndex.Value; } }
    public bool hasWayPointsMoveIndex { get { return HasComponent(GameComponentsLookup.WayPointsMoveIndex); } }

    public GameEntity AddWayPointsMoveIndex(int newValue) {
        var index = GameComponentsLookup.WayPointsMoveIndex;
        var component = (Code.Gameplay.Features.Movement.WayPointsMoveIndex)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.WayPointsMoveIndex));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceWayPointsMoveIndex(int newValue) {
        var index = GameComponentsLookup.WayPointsMoveIndex;
        var component = (Code.Gameplay.Features.Movement.WayPointsMoveIndex)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.WayPointsMoveIndex));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveWayPointsMoveIndex() {
        RemoveComponent(GameComponentsLookup.WayPointsMoveIndex);
        return this;
    }
}
