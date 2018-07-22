using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class LastJumpTimeComponent : IComponent
{
    public float Value;
}