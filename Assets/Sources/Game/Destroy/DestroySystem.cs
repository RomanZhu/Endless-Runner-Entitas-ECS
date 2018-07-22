using System.Collections.Generic;
using Entitas;

public sealed class DestroySystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _gameGroup;
    private readonly List<GameEntity> _gameBuffer;
    
    public DestroySystem(Contexts contexts)
    {
        _gameGroup  = contexts.game.GetGroup(GameMatcher.Destroyed);
        _gameBuffer = new List<GameEntity>();
    }
    
    public void Execute()
    {
        foreach (var e in _gameGroup.GetEntities(_gameBuffer))
        {
            e.Destroy();
        }
    }
}