using Entitas;
using UnityEngine;

public sealed class CreateChunksSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IdService _idService;
    private readonly CreateChunkService _createChunkService;
    
    public CreateChunksSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _idService = services.IdService;
        _createChunkService = services.CreateChunkService;
    }
    
    public void Execute()
    {
        var player = _contexts.game.playerEntity;
        if (player != null && player.hasPosition)
        {
            var playerPosition = player.position.Value;
            var nextChunkPosition = _contexts.gameState.nextChunkPosition.Value;
            var chunkDistance = _contexts.config.chunkCreationDistance.Value;

            if (playerPosition.x + chunkDistance > nextChunkPosition)
            {
                var definitions = _contexts.config.chunkDefinitions.Value.Definitions;
                var definition = definitions[Random.Range(0, definitions.Count)];
                
                _contexts.gameState.ReplaceNextChunkPosition(nextChunkPosition + definition.Width);
                _createChunkService.CreateChunk(_idService.GetNext(), new Vector2(nextChunkPosition, 0f), definition);
            }
        }       
    }
}