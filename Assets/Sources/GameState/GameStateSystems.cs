public class GameStateSystems : Feature
{
    public GameStateSystems(Contexts contexts, Services services)
    {
        Add(new InitGameStateSystem(contexts));

        Add(new JumpSystems(contexts, services));

        Add(new ChangePlayerTypeSystem(contexts));

        Add(new SetTargetVelocitySystem(contexts));
        Add(new MoveCurrentVelocityToTargetSystem(contexts));
    }
}