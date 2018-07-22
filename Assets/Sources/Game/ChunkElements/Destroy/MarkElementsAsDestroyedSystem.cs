using System.Collections.Generic;
using Entitas;

public sealed class MarkElementsAsDestroyedSystem : ReactiveSystem<GameEntity>
{

    private readonly Contexts _contexts;

    public MarkElementsAsDestroyedSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isChunk;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var child in _contexts.game.GetEntitiesWithChildOf(entity.id.Value))
            {
                child.isDestroyed = true;
            }
        }
    }
}