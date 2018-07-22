using Entitas;
using UnityEngine;

public sealed class InitGameStateSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public InitGameStateSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var state = _contexts.gameState;

        state.isLanded           = true;
        state.isJumping          = false;
        state.isJumpImpulseFired = false;
        state.isApplyJump        = false;
        state.ReplaceCurrentMaxVelocity(Vector2.zero);
        state.ReplaceTargetMaxVelocity(Vector2.zero);
        state.ReplaceCurrentJumpCount(0);
        state.ReplaceLastJumpTime(0f);
        state.ReplaceNextChunkPosition(0f);
        state.ReplacePlayerType(0);
    }
}