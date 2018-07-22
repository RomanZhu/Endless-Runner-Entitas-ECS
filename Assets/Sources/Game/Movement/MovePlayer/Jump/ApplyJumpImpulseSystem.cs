using Entitas;

public sealed class ApplyJumpImpulseSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    
    public ApplyJumpImpulseSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        var state = _contexts.gameState;
        if (state.isApplyJump && !state.isJumpImpulseFired)
        {
            var player = _contexts.game.playerEntity;
            if (player != null && player.hasRigidbody)
            {
                player.rigidbody.Value.AddImpulse(_contexts.config.jumpImpulse.Value);
                state.isJumpImpulseFired = true;
            }
        }
    }
}