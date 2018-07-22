using Entitas;

public interface IViewService
{
    void LoadAsset(Contexts contexts, GameEntity entity, string assetName);
    void LinkChildsToEntities(Contexts contexts, IView view, IdService idService);
}