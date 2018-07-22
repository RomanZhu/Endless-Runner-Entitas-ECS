using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Config]
[Unique]
public sealed class JumpImpulseComponent : IComponent
{
    public Vector2 Value;
}