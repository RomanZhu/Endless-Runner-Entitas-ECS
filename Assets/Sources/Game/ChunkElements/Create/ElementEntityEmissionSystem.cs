using System.Collections.Generic;
using Entitas;

public sealed class ElementEntityEmissionSystem : ReactiveSystem<GameEntity>
{

    private readonly Contexts _contexts;
    private readonly IdService _idService;
    private readonly IViewService _viewService;

    public ElementEntityEmissionSystem(Contexts contexts, Services services) : base(contexts.game)
    {
        _contexts = contexts;
        _idService = services.IdService;
        _viewService = services.ViewService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Chunk);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            _viewService.LinkChildsToEntities(_contexts, entity.view.Value, _idService);
        }
    }
}