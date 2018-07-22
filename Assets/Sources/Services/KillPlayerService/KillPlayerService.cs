public class KillPlayerService : Service
{
    public KillPlayerService(Contexts contexts) : base(contexts)
    {
    }

    public void Kill(GameEntity player)
    {
        if (!player.isDead)
        {
            player.isDead = true;

            var e = _contexts.game.CreateEntity();
            e.AddTimer(_contexts.config.playerRespawnDelay.Value);
            e.isRespawn = true;
        }
    }
}