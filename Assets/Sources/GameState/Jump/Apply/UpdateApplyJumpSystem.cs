using Entitas;

public sealed class UpdateApplyJumpSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    
    public UpdateApplyJumpSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        var state = _contexts.gameState;
        state.isApplyJump = _contexts.input.rightSidePointerEntity.isPointerHolding && state.isJumping && !state.isJumpTimedOut && !state.isJumpFinished;
    }
}