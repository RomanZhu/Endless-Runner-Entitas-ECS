public class FixedUpdateSystems : Feature
{
    public FixedUpdateSystems(Contexts contexts, Services services)
    {
        Add(new GameSystems(contexts, services));
        Add(new GameEventSystems(contexts));

        Add(new DestroySystem(contexts));
    }
}