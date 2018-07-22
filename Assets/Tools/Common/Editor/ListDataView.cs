using System;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[Serializable]
public abstract class ListDataView<T> where T : class, new()
{
    [SerializeField]
    public List<T> Data = new List<T>();
    
    [SerializeField]
    public int SelectedId = -1;
    
    [SerializeField]
    private ReorderableList _list;
    
    [SerializeField]
    private Vector2 _leftColumnScrollPosition = Vector2.zero;
    [SerializeField]
    private Vector2 _rightColumnScrollPosition = Vector2.zero;
    
    public void Draw()
    {
        GUILayout.BeginHorizontal();
        
        GUILayout.BeginVertical(GUILayout.Width(150f));
        _leftColumnScrollPosition = GUILayout.BeginScrollView(_leftColumnScrollPosition, false, false);
        DrawLeftColumn();
        GUILayout.EndScrollView();
        GUILayout.EndVertical();
        
        GUILayout.BeginVertical(GUI.skin.box);
        DrawRightColumn();
        GUILayout.EndVertical();
        
        GUILayout.EndHorizontal();
    }

    public void InitializeList()
    {
        _list = new ReorderableList(Data, typeof(T), true, false, true, true)
        {
            onSelectCallback = list =>
            {
                SelectedId = list.index; 
            },
            onAddCallback = list =>
            {
                Data.Add(new T());
                _list.index = Data.Count - 1;
                SelectedId = list.index;
            },
            onRemoveCallback = list =>
            {
                Data.RemoveAt(_list.index);
                if (Data.Count < SelectedId + 1)
                {
                    _list.index = Data.Count - 1;
                    SelectedId = _list.index;
                }
            },
            drawHeaderCallback = rect => { GUI.Label(rect, GetHeaderName()); },
            drawElementCallback = (rect, index, active, focused) =>
            {
                var color = GUI.color;
                if (!IsElementValid(Data[index]))
                    GUI.color = new Color(1f, 0.57f, 0.54f);
                    
                GUI.Label(rect, GetElementName(Data[index]));
                GUI.color = color;
            }
        };
    }

    public void UpdateSelection()
    {
        _list.index = SelectedId;
    }
    
    private void DrawLeftColumn()
    {
        _list.DoLayoutList();
    }
    
    private void DrawRightColumn()
    {
        if (SelectedId >= 0)
        {
            DrawEditScreen();
        }
        else
        {
            DrawEmptyScreen();
        }
    }
    
    private void DrawEditScreen()
    {
        var element = Data[SelectedId];

        DrawElementHeader(element);
        _rightColumnScrollPosition = GUILayout.BeginScrollView(_rightColumnScrollPosition,false, false);
        DrawElementBody(element);
        GUILayout.EndScrollView();
    }

    private void DrawEmptyScreen()
    {
        GUILayout.Label("Select anything to edit.");
    }
    
    protected abstract string GetHeaderName();
    
    protected abstract bool IsElementValid(T element);

    protected abstract string GetElementName(T element);
    
    protected abstract void DrawElementHeader(T element);
    
    protected abstract void DrawElementBody(T element);
}