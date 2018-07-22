using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class AdditionalMidAirGravityComponent : IComponent
{
    public float Value;
}