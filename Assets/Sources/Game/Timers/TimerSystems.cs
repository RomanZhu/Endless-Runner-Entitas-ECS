public class TimerSystems : Feature
{
    public TimerSystems(Contexts contexts, Services services)
    {
        Add(new DecreaseTimersSystem(contexts));
        Add(new RemoveTimersSystem(contexts));
    }
}