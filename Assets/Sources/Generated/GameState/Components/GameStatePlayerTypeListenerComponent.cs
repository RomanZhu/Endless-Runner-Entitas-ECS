//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    public PlayerTypeListenerComponent playerTypeListener { get { return (PlayerTypeListenerComponent)GetComponent(GameStateComponentsLookup.PlayerTypeListener); } }
    public bool hasPlayerTypeListener { get { return HasComponent(GameStateComponentsLookup.PlayerTypeListener); } }

    public void AddPlayerTypeListener(System.Collections.Generic.List<IPlayerTypeListener> newValue) {
        var index = GameStateComponentsLookup.PlayerTypeListener;
        var component = CreateComponent<PlayerTypeListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerTypeListener(System.Collections.Generic.List<IPlayerTypeListener> newValue) {
        var index = GameStateComponentsLookup.PlayerTypeListener;
        var component = CreateComponent<PlayerTypeListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerTypeListener() {
        RemoveComponent(GameStateComponentsLookup.PlayerTypeListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherPlayerTypeListener;

    public static Entitas.IMatcher<GameStateEntity> PlayerTypeListener {
        get {
            if (_matcherPlayerTypeListener == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentsLookup.PlayerTypeListener);
                matcher.componentNames = GameStateComponentsLookup.componentNames;
                _matcherPlayerTypeListener = matcher;
            }

            return _matcherPlayerTypeListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    public void AddPlayerTypeListener(IPlayerTypeListener value) {
        var listeners = hasPlayerTypeListener
            ? playerTypeListener.value
            : new System.Collections.Generic.List<IPlayerTypeListener>();
        listeners.Add(value);
        ReplacePlayerTypeListener(listeners);
    }

    public void RemovePlayerTypeListener(IPlayerTypeListener value, bool removeComponentWhenEmpty = true) {
        var listeners = playerTypeListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemovePlayerTypeListener();
        } else {
            ReplacePlayerTypeListener(listeners);
        }
    }
}
