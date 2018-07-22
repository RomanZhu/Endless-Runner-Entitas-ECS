public class UpdateSystems : Feature
{
    public UpdateSystems(Contexts contexts, Services services)
    {
        Add(new ConfigEventSystems(contexts));
        
        Add(new InputSystems(contexts, services));

        Add(new GameStateSystems(contexts, services));
        Add(new GameStateEventSystems(contexts));
    }
}