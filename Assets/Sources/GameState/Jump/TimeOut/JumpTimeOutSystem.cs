using Entitas;

public sealed class JumpTimeOutSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    
    public JumpTimeOutSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        var state = _contexts.gameState;

        if (state.isJumping)
        {
            var time = _contexts.input.realtimeSinceStartup.value;
            var currentJumpTime = time - state.lastJumpTime.Value;

            state.isJumpTimedOut = currentJumpTime >  _contexts.config.maxJumpTime.Value;
        }
    }
}