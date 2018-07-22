using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState]
[Unique]
public sealed class NextChunkPositionComponent : IComponent
{
    public float Value;
}