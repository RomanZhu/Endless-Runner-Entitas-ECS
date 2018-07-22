public class GameSystems : Feature
{
    public GameSystems(Contexts contexts, Services services)
    {
        Add(new TimerSystems(contexts, services));
        
        Add(new InitCreatePlayerSystem(contexts, services));
        Add(new RespawnSystem(contexts));
        Add(new CreateChunksSystem(contexts, services));

        Add(new ViewSystem(contexts, services));
        Add(new ApplyPositionSystem(contexts));
        Add(new ElementEntityEmissionSystem(contexts, services));

        Add(new ApplyRandomTypeSystem(contexts));
        Add(new ApplyPlayerColorSystem(contexts));
        Add(new ApplyPlatformColorSystem(contexts));
        
        Add(new MovementSystems(contexts, services));
        Add(new CollisionEmissionSystem(contexts, services));
        Add(new LandDetectionSystem(contexts));

        Add(new PlatformKillPlayerSystem(contexts, services));
        Add(new HeightKillPlayerSystem(contexts, services));

        Add(new EnableDisableViewSystem(contexts));

        Add(new MarkChunksAsDestroyedSystem(contexts));
        Add(new MarkElementsAsDestroyedSystem(contexts));
        Add(new MarkCollisionAsDestroyedSystem(contexts));
    }
}