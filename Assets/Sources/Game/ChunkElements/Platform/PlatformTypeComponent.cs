using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Self)]
public sealed class PlatformTypeComponent : IComponent
{
    public int Value;
}