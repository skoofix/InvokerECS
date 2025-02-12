//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Code.Gameplay.Features.Invoker;

public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherOrbForCast;

    public static Entitas.IMatcher<GameEntity> OrbForCast {
        get {
            if (_matcherOrbForCast == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OrbForCast);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOrbForCast = matcher;
            }

            return _matcherOrbForCast;
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

    public Code.Gameplay.Features.Spells.OrbForCastComponent orbForCast { get { return (Code.Gameplay.Features.Spells.OrbForCastComponent)GetComponent(GameComponentsLookup.OrbForCast); } }
    public System.Collections.Generic.List<OrbTypeId> OrbForCast { get { return orbForCast.Value; } }
    public bool hasOrbForCast { get { return HasComponent(GameComponentsLookup.OrbForCast); } }

    public GameEntity AddOrbForCast(System.Collections.Generic.List<OrbTypeId> newValue) {
        var index = GameComponentsLookup.OrbForCast;
        var component = (Code.Gameplay.Features.Spells.OrbForCastComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Spells.OrbForCastComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceOrbForCast(System.Collections.Generic.List<OrbTypeId> newValue) {
        var index = GameComponentsLookup.OrbForCast;
        var component = (Code.Gameplay.Features.Spells.OrbForCastComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Spells.OrbForCastComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveOrbForCast() {
        RemoveComponent(GameComponentsLookup.OrbForCast);
        return this;
    }
}
