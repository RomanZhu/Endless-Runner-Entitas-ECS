using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
[Event(EventTarget.Any)]
[Event(EventTarget.Any, EventType.Removed)]
public sealed class ApplyJumpComponent : IComponent {}