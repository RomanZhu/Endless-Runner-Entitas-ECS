using UnityEngine;

public interface IEntityEmitter
{
    Transform Transform { get; }
    GameEntity Emit();
}