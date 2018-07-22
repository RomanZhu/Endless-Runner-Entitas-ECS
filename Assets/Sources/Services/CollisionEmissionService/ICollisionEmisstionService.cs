using UnityEngine;

public interface ICollisionEmisstionService
{
    void Emit(RaycastHit hit);
}