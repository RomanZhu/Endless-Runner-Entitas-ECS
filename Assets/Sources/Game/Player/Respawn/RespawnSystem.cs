using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class RespawnSystem : ReactiveSystem<GameEntity>
{

    private readonly Contexts _contexts;

    public RespawnSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Respawn.Added(), GameMatcher.Timer.Removed());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isRespawn && !entity.hasTimer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var player = _contexts.game.playerEntity;
        var position =  new Vector2(_contexts.gameState.nextChunkPosition.Value, _contexts.config.startPlayerPosition.Value.y);

        player.isDead = false;
        player.position.Value = position;
        
        _contexts.gameState.ReplacePlayerType(0);
    }
}