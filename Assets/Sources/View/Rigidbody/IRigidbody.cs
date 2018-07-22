using UnityEngine;

public interface IRigidbody
{
    Vector2 Velocity { get; set; }
    
    void AddForce(Vector2 force);
    void AddImpulse(Vector2 force);
}