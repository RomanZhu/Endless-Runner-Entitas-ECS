using Entitas;

public sealed class UpdatePointerSystem : IExecuteSystem
{
    private readonly Contexts      _contexts;
    private readonly IInputService _inputService;

    public UpdatePointerSystem(Contexts contexts, Services services)
    {
        _contexts     = contexts;
        _inputService = services.InputService;
    }

    public void Execute()
    {
        _inputService.Update(_contexts.input.deltaTime.value);

        var left = _contexts.input.leftSidePointerEntity;
        left.isPointerHolding = _inputService.IsHoldingLeft();
        left.isPointerStartedHolding = _inputService.IsStartedHoldingLeft();
        left.isPointerReleased = _inputService.IsReleasedLeft();
        left.ReplacePointerHoldingTime(_inputService.HoldingTimeLeft());
        
        var right = _contexts.input.rightSidePointerEntity;
        right.isPointerHolding        = _inputService.IsHoldingRight();
        right.isPointerStartedHolding = _inputService.IsStartedHoldingRight();
        right.isPointerReleased       = _inputService.IsReleasedRight();
        right.ReplacePointerHoldingTime(_inputService.HoldingTimeRight());
    }
}