using Entitas;

public sealed class EndJumpOnStuckSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly JumpService _jumpService;

    public EndJumpOnStuckSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _jumpService = services.JumpService;
    }
    
    public void Execute()
    {
        var state = _contexts.gameState;

        if (state.isJumping && state.isLanded)
        {
            var stuckTime = state.lastJumpTime.Value + _contexts.config.jumpEndOnStuckTimeout.Value;
            if (stuckTime < _contexts.input.realtimeSinceStartup.value)
            {
                _jumpService.EndJump();
            }
        }
    }
}