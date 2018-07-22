using Entitas;

public sealed class SyncPlayerPositionSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    
    public SyncPlayerPositionSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        var player = _contexts.game.playerEntity;
        if (player != null && player.hasView)
        {
            player.ReplacePosition(player.view.Value.Position);
        }
    }
}