using System.Collections.Generic;
using Entitas;

public sealed class ApplyPositionSystem : ReactiveSystem<GameEntity>
{

    public ApplyPositionSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.View.Added(), GameMatcher.Dead.Removed());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.Value.Position = entity.position.Value;
        }
    }
}