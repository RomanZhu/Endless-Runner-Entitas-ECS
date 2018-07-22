using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class ChunkCreationDistanceComponent : IComponent
{
    public float Value;
}