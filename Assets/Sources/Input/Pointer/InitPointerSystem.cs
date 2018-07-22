using Entitas;

public sealed class InitPointerSystem : IInitializeSystem
{
    private readonly Contexts _contexts;
    
    public InitPointerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var e = _contexts.input.CreateEntity();
        e.isLeftSidePointer = true;
        AddCommon(e);
        
        e = _contexts.input.CreateEntity();
        e.isRightSidePointer = true;
        AddCommon(e);
    }

    void AddCommon(InputEntity e)
    {
        e.AddPointerHoldingTime(0f);
        e.isPointerStartedHolding = false;
        e.isPointerHolding        = false;
        e.isPointerReleased       = false;
    }
}