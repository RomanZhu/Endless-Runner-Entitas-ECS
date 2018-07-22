public class JumpSystems : Feature
{
    public JumpSystems(Contexts contexts, Services services)
    {
        Add(new EndJumpOnLandingSystem(contexts, services));
        Add(new EndJumpOnStuckSystem(contexts, services));
        Add(new SuccessiveJumpSystem(contexts, services));
        Add(new BeginJumpSystem(contexts, services));
        Add(new JumpTimeOutSystem(contexts));
        Add(new FinishJumpSystem(contexts));
        
        Add(new UpdateApplyJumpSystem(contexts));
    }
}