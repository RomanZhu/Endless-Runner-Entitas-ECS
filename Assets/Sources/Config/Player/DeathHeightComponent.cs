using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
[Event(EventTarget.Self)]
public sealed class DeathHeightComponent : IComponent
{
    public float Value;
}