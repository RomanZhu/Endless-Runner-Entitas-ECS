using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
[Unique]
public sealed class RealtimeSinceStartupComponent : IComponent
{
    public float value;
}