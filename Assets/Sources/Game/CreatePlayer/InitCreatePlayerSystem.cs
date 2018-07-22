using Entitas;

public sealed class InitCreatePlayerSystem : IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly Services _services;

    public InitCreatePlayerSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _services = services;
    }

    public void Initialize()
    {
        var id = _services.IdService.GetNext();
        _services.CreatePlayerService.CreatePlayer(id, _contexts.config.startPlayerPosition.Value);
    }
}