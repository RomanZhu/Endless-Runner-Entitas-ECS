public class InputSystems : Feature
{
    public InputSystems(Contexts contexts, Services services)
    {
        Add(new InitPointerSystem(contexts));

        Add(new UpdateTimeSystem(contexts, services));
        Add(new UpdatePointerSystem(contexts, services));
    }
}