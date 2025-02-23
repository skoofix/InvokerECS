//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherActiveOrbs;

    public static Entitas.IMatcher<GameEntity> ActiveOrbs {
        get {
            if (_matcherActiveOrbs == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ActiveOrbs);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherActiveOrbs = matcher;
            }

            return _matcherActiveOrbs;
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

    public Code.Gameplay.Features.Invoker.ActiveOrbs activeOrbs { get { return (Code.Gameplay.Features.Invoker.ActiveOrbs)GetComponent(GameComponentsLookup.ActiveOrbs); } }
    public System.Collections.Generic.List<Code.Gameplay.Features.Invoker.OrbTypeId> ActiveOrbs { get { return activeOrbs.Value; } }
    public bool hasActiveOrbs { get { return HasComponent(GameComponentsLookup.ActiveOrbs); } }

    public GameEntity AddActiveOrbs(System.Collections.Generic.List<Code.Gameplay.Features.Invoker.OrbTypeId> newValue) {
        var index = GameComponentsLookup.ActiveOrbs;
        var component = (Code.Gameplay.Features.Invoker.ActiveOrbs)CreateComponent(index, typeof(Code.Gameplay.Features.Invoker.ActiveOrbs));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceActiveOrbs(System.Collections.Generic.List<Code.Gameplay.Features.Invoker.OrbTypeId> newValue) {
        var index = GameComponentsLookup.ActiveOrbs;
        var component = (Code.Gameplay.Features.Invoker.ActiveOrbs)CreateComponent(index, typeof(Code.Gameplay.Features.Invoker.ActiveOrbs));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveActiveOrbs() {
        RemoveComponent(GameComponentsLookup.ActiveOrbs);
        return this;
    }
}
