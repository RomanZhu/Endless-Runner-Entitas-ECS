using Entitas;
using UnityEngine;

public sealed class ApplyAdditionalMidAirGravitySystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public ApplyAdditionalMidAirGravitySystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (!_contexts.gameState.isApplyJump && !_contexts.gameState.isLanded)
        {
            var player = _contexts.game.playerEntity;
            if (player != null && player.hasRigidbody)
            {
                player.rigidbody.Value.AddForce(new Vector2(0f, _contexts.config.additionalMidAirGravity.Value));
            }
        }
    }
}
