using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any)]
public sealed class PlayerTypeComponent : IComponent
{
    public int Value;
}