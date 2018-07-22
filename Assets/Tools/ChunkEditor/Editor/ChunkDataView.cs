using UnityEditor;
using UnityEngine;

public class ChunkDataView : ListDataView<ChunkDefinition>
{
    private const string Path = "Chunks/";
    
    [SerializeField]
    private GameObject _viewObject;
    [SerializeField]
    private UnityChunk _chunk;
    [SerializeField]
    private Editor _view;
    [SerializeField]
    private GUIStyle _style;
    
    protected override string GetHeaderName()
    {
        return "Chunks";
    }

    protected override bool IsElementValid(ChunkDefinition element)
    {
        var viewObject = Resources.Load<GameObject>(string.Format("Prefabs/{0}", element.Asset));
        return viewObject != null && viewObject.GetComponent<UnityChunk>() != null;
    }

    protected override string GetElementName(ChunkDefinition element)
    {
        return string.Format("{0}", element.Asset.Replace(Path, ""));
    }

    protected override void DrawElementHeader(ChunkDefinition element)
    {
        GUILayout.BeginHorizontal(GUI.skin.box);
        GUILayout.Label("Asset");
        element.Asset =
            string.Format("{0}{1}", Path, EditorGUILayout.DelayedTextField(element.Asset.Replace(Path, "")));

        EditorGUI.BeginDisabledGroup(true);
        GUILayout.Label("Width");
        EditorGUILayout.LabelField(element.Width.ToString());

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();
    }

    protected override void DrawElementBody(ChunkDefinition element)
    {
        if (IsElementValid(element))
        {
            if (_style == null)
            {
                _style = new GUIStyle
                {
                    normal =
                    {
                        background = (Texture2D) AssetDatabase.LoadMainAssetAtPath(
                            "Assets/Tools/ChunkEditor/Editor/PreviewBackground.png")
                    }
                };
            }
            
            if (_viewObject == null || _viewObject.name != element.Asset)
            {
                _viewObject = Resources.Load<GameObject>(string.Format("Prefabs/{0}", element.Asset));
                _chunk = _viewObject.GetComponent<UnityChunk>();
                _view = Editor.CreateEditor(_viewObject);
            }

            element.Width = _chunk.Width;

            _view.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(250, 500), _style);
        }
        else
        {
            GUILayout.Label("Invalid asset path or there is no Chunk component attached.\n Prefab should be located in Resources/Prefabs/Chunks/");
        }
    }
}