public sealed class JumpService : Service
{
    public JumpService(Contexts contexts) : base(contexts)
    {
    }

    public void BeginJump(float time)
    {
        var state = _contexts.gameState;

        state.isJumping          = true;
        state.isJumpImpulseFired = false;
        state.isJumpTimedOut = false;
        state.isJumpFinished = false;
        state.ReplaceCurrentJumpCount(1);
        state.ReplaceLastJumpTime(time);
    }

    public void SuccessiveJump(float time)
    {
        var state = _contexts.gameState;
        var count = state.currentJumpCount.Value + 1;

        state.isJumpImpulseFired = false;
        state.isJumpTimedOut = false;
        state.isJumpFinished = false;
        state.ReplaceCurrentJumpCount(count);
        state.ReplaceLastJumpTime(time);
    }

    public void EndJump()
    {
        var state = _contexts.gameState;

        state.isJumping = false;
    }
}