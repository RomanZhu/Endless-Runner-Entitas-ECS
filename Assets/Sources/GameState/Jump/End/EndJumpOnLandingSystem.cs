using System.Collections.Generic;
using Entitas;

public sealed class EndJumpOnLandingSystem : ReactiveSystem<GameStateEntity>
{
    private readonly Contexts    _contexts;
    private readonly JumpService _jumpService;

    public EndJumpOnLandingSystem(Contexts contexts, Services services) : base(contexts.gameState)
    {
        _contexts    = contexts;
        _jumpService = services.JumpService;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
    {
        return context.CreateCollector(GameStateMatcher.Landed);
    }

    protected override bool Filter(GameStateEntity entity)
    {
        return entity.isLanded;
    }

    protected override void Execute(List<GameStateEntity> entities)
    {
        if (_contexts.gameState.isJumping)
            _jumpService.EndJump();
    }
}