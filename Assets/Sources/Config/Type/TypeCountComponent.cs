using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class TypeCountComponent : IComponent
{
    public int Value;
}