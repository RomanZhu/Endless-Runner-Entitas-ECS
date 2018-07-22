using System.Collections.Generic;
using Entitas;

public sealed class DecreaseTimersSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity>   _buffer;
    
    public DecreaseTimersSystem(Contexts contexts)
    {
        _contexts = contexts;
        
        _group  = contexts.game.GetGroup(GameMatcher.Timer);
        _buffer = new List<GameEntity>();
    }
    
    public void Execute()
    {
        foreach (var timer in _group.GetEntities(_buffer))
        {
            timer.ReplaceTimer(timer.timer.Value - _contexts.input.fixedDeltaTime.Value);
        }
    }
}