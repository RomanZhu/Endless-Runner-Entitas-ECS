using UnityEngine;

public class UnityCollisionEmissionService : Service, ICollisionEmisstionService
{
    public UnityCollisionEmissionService(Contexts contexts) : base(contexts)
    {
    }

    public void Emit(RaycastHit hit)
    {
        var e = _contexts.game.CreateEntity();
        e.isCollision = true;

        //We could optimize it using dictionary, for example map every collider of a view to Id on creation
        var view = hit.collider.gameObject.GetComponent<IView>();
        if (view != null)
        {
            e.AddColliderId(view.Id);
        }
    }
}