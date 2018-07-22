using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UnityChunk))]
public class UnityChunkInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Calculate"))
        {
            float maxWidth = 0;
            var chunk = (UnityChunk) target;
            var renderers = chunk.GetComponentsInChildren<Renderer>();
            foreach (var renderer in renderers)
            {
                if (maxWidth < renderer.transform.localPosition.x)
                    maxWidth = renderer.transform.localPosition.x;
            }

            chunk.Width = maxWidth;
        }
    }
}