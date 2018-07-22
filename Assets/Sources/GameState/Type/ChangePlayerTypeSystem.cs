using System.Collections.Generic;
using Entitas;

public sealed class ChangePlayerTypeSystem : ReactiveSystem<InputEntity>
{

    private readonly Contexts    _contexts;

    public ChangePlayerTypeSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.PointerStartedHolding);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isLeftSidePointer && entity.isPointerStartedHolding;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if(_contexts.game.playerEntity.isDead) return;
        
        var state = _contexts.gameState;
        var type = state.playerType.Value;
        var max  = _contexts.config.typeCount.Value;

        type++;
        if (type == max)
            type = 0;

        state.ReplacePlayerType(type);
    }
}