using UnityEngine;

/// <summary>
/// Helper for Width measuring (see ChunkDataView)
/// </summary>
public class UnityChunk : MonoBehaviour
{
    public float Width;

    private void OnDrawGizmos()
    {
        var center = new Vector3(transform.position.x + Width / 2, transform.position.y, transform.position.z);
        Gizmos.DrawWireCube(center, new Vector3(Width, 10f, 5f));
    }
}