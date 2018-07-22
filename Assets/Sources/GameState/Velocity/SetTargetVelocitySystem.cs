using Entitas;

public sealed class SetTargetVelocitySystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    
    public SetTargetVelocitySystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        var state = _contexts.gameState;
        if (state.isApplyJump)
        {
            var maxVelocity = _contexts.config.jumpMaxVelocity.Value;
            if(state.targetMaxVelocity.Value != maxVelocity)
                state.ReplaceTargetMaxVelocity(maxVelocity);
        }
        else
        {
            var maxVelocity = _contexts.config.standardMaxVelocity.Value;
            if(state.targetMaxVelocity.Value != maxVelocity)
                state.ReplaceTargetMaxVelocity(maxVelocity);
        }
    }
}