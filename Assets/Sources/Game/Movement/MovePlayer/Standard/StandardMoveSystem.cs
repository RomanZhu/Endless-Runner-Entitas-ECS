using Entitas;
using UnityEngine;

public sealed class StandardMoveSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public StandardMoveSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (!_contexts.gameState.isApplyJump)
        {
            var player = _contexts.game.playerEntity;
            if (player != null && player.hasRigidbody)
            {
                player.rigidbody.Value.AddForce(_contexts.config.standardAcceleration.Value);
            }
        }
    }
}