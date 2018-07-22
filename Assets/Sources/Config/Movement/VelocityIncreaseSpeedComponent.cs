using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class VelocityIncreaseSpeedComponent : IComponent
{
    public float Value;
}