//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReachedEnd;

    public static Entitas.IMatcher<GameEntity> ReachedEnd {
        get {
            if (_matcherReachedEnd == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReachedEnd);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReachedEnd = matcher;
            }

            return _matcherReachedEnd;
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

    static readonly Code.Gameplay.Features.Spells.ReachedEnd reachedEndComponent = new Code.Gameplay.Features.Spells.ReachedEnd();

    public bool isReachedEnd {
        get { return HasComponent(GameComponentsLookup.ReachedEnd); }
        set {
            if (value != isReachedEnd) {
                var index = GameComponentsLookup.ReachedEnd;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : reachedEndComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
