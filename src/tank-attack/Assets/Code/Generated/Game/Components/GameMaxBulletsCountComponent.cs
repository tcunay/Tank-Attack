//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMaxBulletsCount;

    public static Entitas.IMatcher<GameEntity> MaxBulletsCount {
        get {
            if (_matcherMaxBulletsCount == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MaxBulletsCount);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMaxBulletsCount = matcher;
            }

            return _matcherMaxBulletsCount;
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

    public Code.Gameplay.Features.Armaments.ArmamentComponents.MaxBulletsCount maxBulletsCount { get { return (Code.Gameplay.Features.Armaments.ArmamentComponents.MaxBulletsCount)GetComponent(GameComponentsLookup.MaxBulletsCount); } }
    public float MaxBulletsCount { get { return maxBulletsCount.Value; } }
    public bool hasMaxBulletsCount { get { return HasComponent(GameComponentsLookup.MaxBulletsCount); } }

    public GameEntity AddMaxBulletsCount(float newValue) {
        var index = GameComponentsLookup.MaxBulletsCount;
        var component = (Code.Gameplay.Features.Armaments.ArmamentComponents.MaxBulletsCount)CreateComponent(index, typeof(Code.Gameplay.Features.Armaments.ArmamentComponents.MaxBulletsCount));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceMaxBulletsCount(float newValue) {
        var index = GameComponentsLookup.MaxBulletsCount;
        var component = (Code.Gameplay.Features.Armaments.ArmamentComponents.MaxBulletsCount)CreateComponent(index, typeof(Code.Gameplay.Features.Armaments.ArmamentComponents.MaxBulletsCount));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveMaxBulletsCount() {
        RemoveComponent(GameComponentsLookup.MaxBulletsCount);
        return this;
    }
}
