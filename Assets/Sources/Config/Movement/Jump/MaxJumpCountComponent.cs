using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class MaxJumpCountComponent : IComponent
{
    public int Value;
}