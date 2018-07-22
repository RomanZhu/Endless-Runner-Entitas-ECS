using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class PlayerSphereRadiusComponent : IComponent
{
    public float Value;
}