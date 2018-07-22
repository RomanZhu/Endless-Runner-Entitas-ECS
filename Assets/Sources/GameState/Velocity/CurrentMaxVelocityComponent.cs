using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[GameState]
[Unique]
public sealed class CurrentMaxVelocityComponent : IComponent
{
    public Vector2 Value;
}