using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class ChunkDestructionDistanceComponent : IComponent
{
    public float Value;
}