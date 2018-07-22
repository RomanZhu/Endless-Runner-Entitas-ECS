using System.Collections.Generic;
using Entitas;

public sealed class RemoveTimersSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity>   _buffer;
    
    public RemoveTimersSystem(Contexts contexts)
    {        
        _group  = contexts.game.GetGroup(GameMatcher.Timer);
        _buffer = new List<GameEntity>();
    }
    
    public void Execute()
    {
        foreach (var timer in _group.GetEntities(_buffer))
        {
            if (timer.timer.Value < 0f)
            {
                timer.RemoveTimer();
                timer.isDestroyed = true;
            }
        }
    }
}