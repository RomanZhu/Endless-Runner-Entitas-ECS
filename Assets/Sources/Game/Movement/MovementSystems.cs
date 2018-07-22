public class MovementSystems : Feature
{
    public MovementSystems(Contexts contexts, Services services)
    {        
        Add(new ApplyJumpImpulseSystem(contexts));
        Add(new JumpMoveSystem(contexts));

        Add(new StandardMoveSystem(contexts));

        Add(new ApplyAdditionalMidAirGravitySystem(contexts));

        Add(new ClampCurrentVelocitySystem(contexts));
        Add(new SyncPlayerPositionSystem(contexts));
    }
}