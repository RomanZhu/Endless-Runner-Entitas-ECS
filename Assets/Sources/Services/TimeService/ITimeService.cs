public interface ITimeService
{
    float FixedDeltaTime();
    float DeltaTime();
    float RealtimeSinceStartup();
}