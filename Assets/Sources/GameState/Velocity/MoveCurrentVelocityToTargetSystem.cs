using Entitas;
using UnityEngine;

public sealed class MoveCurrentVelocityToTargetSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    
    public MoveCurrentVelocityToTargetSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        var state = _contexts.gameState;
        
        var increaseSpeed = _contexts.config.velocityIncreaseSpeed.Value;
        var decreaseSpeed = _contexts.config.velocityDecreaseSpeed.Value;
        var delta = _contexts.input.deltaTime.value;
        var current = state.currentMaxVelocity.Value;
        var target = state.targetMaxVelocity.Value;

        if (current.x > target.x)
        {
            current.x = Mathf.Lerp(current.x, target.x, decreaseSpeed * delta);
        }
        else
        {
            current.x = Mathf.Lerp(current.x, target.x, increaseSpeed * delta);
        }

        if (current.y > target.y)
        {
            current.y = Mathf.Lerp(current.y, target.y, decreaseSpeed * delta);
        }
        else
        {
            current.y = Mathf.Lerp(current.y, target.y, increaseSpeed * delta);
        }
        state.ReplaceCurrentMaxVelocity(current);
    }
}