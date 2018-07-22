using UnityEngine;

public interface IPhysicsService
{
    int SphereCast(Vector2 position, float radius, RaycastHit[] buffer, int layerMask);
}