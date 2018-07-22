using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class MaxJumpTimeComponent : IComponent
{
    public float Value;
}