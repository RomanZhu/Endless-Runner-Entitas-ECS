using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ApplyPlayerColorSystem : ReactiveSystem<GameStateEntity>
{

    private readonly Contexts _contexts;

    public ApplyPlayerColorSystem(Contexts contexts) : base(contexts.gameState)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
    {
        return context.CreateCollector(GameStateMatcher.PlayerType);
    }

    protected override bool Filter(GameStateEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameStateEntity> entities)
    {
        var colors = _contexts.config.typeColorTable.Value;
        var player = _contexts.game.playerEntity;
        if (player != null && player.hasPosition)
        {
            var type = Mathf.Min(_contexts.gameState.playerType.Value, colors.Count);
            player.ReplaceColor(colors[type]);
        }
       
    }
}