using Entitas;

public sealed class UpdateTimeSystem : IExecuteSystem, IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly ITimeService _timeService;

    public UpdateTimeSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _timeService = services.TimeService;
    }

    public void Initialize()
    {
        //Make it bulletproof
        Execute();
    }

    public void Execute()
    {
        _contexts.input.ReplaceFixedDeltaTime(_timeService.FixedDeltaTime());
        _contexts.input.ReplaceDeltaTime(_timeService.DeltaTime());
        _contexts.input.ReplaceRealtimeSinceStartup(_timeService.RealtimeSinceStartup());
    }
}