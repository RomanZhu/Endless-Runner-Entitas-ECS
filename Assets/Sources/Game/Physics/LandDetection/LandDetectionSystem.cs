using System.Collections.Generic;
using Entitas;

public sealed class LandDetectionSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity>   _buffer;
    
    public LandDetectionSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group  = contexts.game.GetGroup(GameMatcher.Collision);
        _buffer = new List<GameEntity>();
    }
    
    public void Execute()
    {
        _contexts.gameState.isLanded = _group.GetEntities(_buffer).Count > 0;
    }
}