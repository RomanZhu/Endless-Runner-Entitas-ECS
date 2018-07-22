using Entitas;

public sealed class HeightKillPlayerSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
        private readonly KillPlayerService _killPlayerService;

    public HeightKillPlayerSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _killPlayerService = services.KillPlayerService;
    }
    
    public void Execute()
    {
        var player = _contexts.game.playerEntity;

        if (player.isDead) return;

        if (player.position.Value.y < _contexts.config.deathHeight.Value)
        {
            _killPlayerService.Kill(player);
        }
    }
}