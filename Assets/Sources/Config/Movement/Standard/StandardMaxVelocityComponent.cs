using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Config]
[Unique]
public sealed class StandardMaxVelocityComponent : IComponent
{
    public Vector2 Value;
}