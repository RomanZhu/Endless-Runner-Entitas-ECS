using System.Collections.Generic;
using Entitas;

public sealed class BeginJumpSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts    _contexts;
    private readonly JumpService _jumpService;

    public BeginJumpSystem(Contexts contexts, Services services) : base(contexts.input)
    {
        _contexts    = contexts;
        _jumpService = services.JumpService;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.PointerStartedHolding);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isRightSidePointer && entity.isPointerStartedHolding;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var time = _contexts.input.realtimeSinceStartup.value;

        if (!_contexts.gameState.isJumping)
            _jumpService.BeginJump(time);
    }
}