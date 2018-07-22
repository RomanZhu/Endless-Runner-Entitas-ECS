using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class ChildOfComponent : IComponent
{
    [EntityIndex]
    public int Value;
}