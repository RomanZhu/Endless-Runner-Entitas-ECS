using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ApplyRandomTypeSystem : ReactiveSystem<GameEntity>
{

    private readonly Contexts _contexts;

    public ApplyRandomTypeSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Platform);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var count = _contexts.config.typeCount.Value;
        foreach (var entity in entities)
        {
            if (entity.isRandomizePlatformType)
            {
                entity.ReplacePlatformType(Random.Range(0, count));
            }
        }
    }
}