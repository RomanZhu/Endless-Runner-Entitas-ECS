using UnityEngine;

public class UnityPhysicsService : Service, IPhysicsService
{    
    public UnityPhysicsService(Contexts contexts) : base(contexts)
    {
    }


    public int SphereCast(Vector2 position, float radius, RaycastHit[] buffer, int layerMask)
    {
        return Physics.SphereCastNonAlloc(position, radius, Vector2.down, buffer, radius,layerMask);
    }
}