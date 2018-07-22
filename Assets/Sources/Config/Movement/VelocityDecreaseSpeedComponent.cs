using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class VelocityDecreaseSpeedComponent : IComponent
{
    public float Value;
}