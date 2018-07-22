using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class CurrentJumpCountComponent : IComponent
{
    public int Value;
}