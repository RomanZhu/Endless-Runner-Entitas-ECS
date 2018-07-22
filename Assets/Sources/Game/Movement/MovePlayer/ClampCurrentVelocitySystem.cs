using Entitas;
using UnityEngine;

public sealed class ClampCurrentVelocitySystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    
    public ClampCurrentVelocitySystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        var player = _contexts.game.playerEntity;
        if (player != null && player.hasRigidbody)
        {
            var maxVelocity = _contexts.gameState.currentMaxVelocity.Value;
            var velocity = player.rigidbody.Value.Velocity;
            velocity = new Vector2(Mathf.Clamp(velocity.x, -maxVelocity.x, maxVelocity.x), Mathf.Clamp(velocity.y, -maxVelocity.y, maxVelocity.y));
            player.rigidbody.Value.Velocity = velocity;
        }
    }
}