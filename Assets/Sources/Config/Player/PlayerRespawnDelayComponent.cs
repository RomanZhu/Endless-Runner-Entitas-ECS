using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class PlayerRespawnDelayComponent : IComponent
{
    public float Value;
}