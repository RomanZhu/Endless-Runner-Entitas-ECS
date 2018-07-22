using System.Collections.Generic;
using Entitas;

public sealed class MarkChunksAsDestroyedSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity>   _buffer;
    
    public MarkChunksAsDestroyedSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group  = contexts.game.GetGroup(GameMatcher.Chunk);
        _buffer = new List<GameEntity>();}
    
    public void Execute()
    {
        var player = _contexts.game.playerEntity;
        if (player != null && player.hasPosition)
        {
            var destructionPosition = player.position.Value.x - _contexts.config.chunkDestructionDistance.Value;
            
            foreach (var chunk in _group.GetEntities(_buffer))
            {
                var chunkCorner = chunk.position.Value.x + chunk.chunkWidth.Value;
                if (destructionPosition > chunkCorner)
                {
                    chunk.isDestroyed = true;
                }
            }
        }
    }
}