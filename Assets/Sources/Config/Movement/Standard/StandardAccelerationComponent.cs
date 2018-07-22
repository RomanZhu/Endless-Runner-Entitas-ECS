using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Config]
[Unique]
public sealed class StandardAccelerationComponent : IComponent
{
    public Vector2 Value;
}