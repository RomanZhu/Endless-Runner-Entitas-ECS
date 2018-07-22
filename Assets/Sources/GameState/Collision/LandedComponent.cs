using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any)]
public sealed class LandedComponent : IComponent
{
}