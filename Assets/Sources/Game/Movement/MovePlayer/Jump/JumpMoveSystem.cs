using Entitas;
using UnityEngine;

public sealed class JumpMoveSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    
    public JumpMoveSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        if (_contexts.gameState.isApplyJump)
        {
            var player = _contexts.game.playerEntity;
            if (player != null && player.hasRigidbody)
            {
                player.rigidbody.Value.AddForce(_contexts.config.jumpAcceleration.Value);
            }
        }
    }
}