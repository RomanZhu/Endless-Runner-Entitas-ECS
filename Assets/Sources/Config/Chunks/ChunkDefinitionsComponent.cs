using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class ChunkDefinitionsComponent : IComponent
{
    public ChunkDefinitions Value;
}