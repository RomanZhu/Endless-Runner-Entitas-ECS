using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class EnableDisableViewSystem : ReactiveSystem<GameEntity>
{
    public EnableDisableViewSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Dead.AddedOrRemoved());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var entity = entities[0];
        entity.view.Value.Enabled = !entity.isDead;
        entity.rigidbody.Value.Velocity = Vector2.zero;
    }
}