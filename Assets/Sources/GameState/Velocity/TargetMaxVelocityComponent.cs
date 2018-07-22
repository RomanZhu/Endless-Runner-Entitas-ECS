using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[GameState]
[Unique]
public sealed class TargetMaxVelocityComponent : IComponent
{
    public Vector2 Value;
}