using System.Collections.Generic;
using Entitas;

public sealed class PlatformKillPlayerSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly KillPlayerService _killPlayerService;
    
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity>   _buffer;
    
    public PlatformKillPlayerSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _killPlayerService = services.KillPlayerService;
        _group  = contexts.game.GetGroup(GameMatcher.Collision);
        _buffer = new List<GameEntity>();
    }
    
    public void Execute()
    {
        var player = _contexts.game.playerEntity;

        if (player.isDead) return;
        
        var playerType = _contexts.gameState.playerType.Value;
        foreach (var collision in _group.GetEntities(_buffer))
        {
            var collider = _contexts.game.GetEntityWithId(collision.colliderId.Value);
            if (collider != null)
            {
                if (collider.hasPlatformType)
                {
                    if (playerType != collider.platformType.Value)
                    {
                        _killPlayerService.Kill(player);
                    }
                }
            }
        }
    }
}