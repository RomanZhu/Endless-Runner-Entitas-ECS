using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
[Unique]
public sealed class DeltaTimeComponent : IComponent
{
    public float value;
}