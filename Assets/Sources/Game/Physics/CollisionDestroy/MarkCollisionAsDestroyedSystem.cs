using System.Collections.Generic;
using Entitas;

public sealed class MarkCollisionAsDestroyedSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity>   _buffer;
    
    public MarkCollisionAsDestroyedSystem(Contexts contexts)
    {
        _group  = contexts.game.GetGroup(GameMatcher.Collision);
        _buffer = new List<GameEntity>();
    }
    
    public void Execute()
    {
        foreach (var e in _group.GetEntities(_buffer))
        {
            e.isDestroyed = true;
        }
    }
}