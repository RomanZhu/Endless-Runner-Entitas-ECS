using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
[Unique]
public sealed class FixedDeltaTimeComponent : IComponent
{
    public float Value;
}