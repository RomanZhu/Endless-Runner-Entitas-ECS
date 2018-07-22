using UnityEngine;

public class CreateChunkService : Service
{
    public CreateChunkService(Contexts contexts) : base(contexts)
    {
    }

    public void CreateChunk(int id, Vector2 position, ChunkDefinition definition)
    {
        var e = _contexts.game.CreateEntity();

        e.isChunk = true;
        e.AddChunkWidth(definition.Width);
        e.AddId(id);
        e.AddAsset(definition.Asset);
        e.AddPosition(position);
    }
}