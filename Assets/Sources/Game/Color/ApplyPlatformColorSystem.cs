using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ApplyPlatformColorSystem : ReactiveSystem<GameEntity>
{

    private readonly Contexts _contexts;

    public ApplyPlatformColorSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.PlatformType);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var colors = _contexts.config.typeColorTable.Value;
        foreach (var entity in entities)
        {
            var type = Mathf.Min(entity.platformType.Value, colors.Count);
            entity.ReplaceColor(colors[type]);
        }
    }
}