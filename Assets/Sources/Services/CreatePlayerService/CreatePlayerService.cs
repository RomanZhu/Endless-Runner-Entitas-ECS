using UnityEngine;

public class CreatePlayerService : Service
{
    public CreatePlayerService(Contexts contexts) : base(contexts)
    {
    }

    public void CreatePlayer(int id, Vector2 position)
    {
        var e = _contexts.game.CreateEntity();

        e.isPlayer = true;
        e.AddId(id);
        e.AddAsset("Player");
        e.AddPosition(position);
    }
}