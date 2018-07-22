using System.Collections.Generic;
using Entitas;

public sealed class FinishJumpSystem : ReactiveSystem<InputEntity>
{

    private readonly Contexts _contexts;

    public FinishJumpSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.PointerReleased);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isRightSidePointer && entity.isPointerReleased;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var state = _contexts.gameState;
        if (state.currentJumpCount.Value == _contexts.config.maxJumpCount.Value)
            state.isJumpFinished = true;
    }
}