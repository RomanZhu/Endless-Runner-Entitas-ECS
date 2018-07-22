using UnityEngine;

public class EffectPushRigidbody : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Vector3 Force;
    public Vector3 Torque;
    
    private void Start()
    {
        Rigidbody.AddForce(Random.Range(0f, Force.x), Random.Range(-Force.y, Force.y), Random.Range(-Force.z, Force.z), ForceMode.Impulse);
        Rigidbody.AddTorque(Random.Range(-Torque.x, Torque.x), Random.Range(-Torque.y, Torque.y), Random.Range(-Torque.z, Torque.z), ForceMode.Impulse);
    }
}