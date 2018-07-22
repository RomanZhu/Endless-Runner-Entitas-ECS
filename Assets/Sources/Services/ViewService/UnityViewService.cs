using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Object = UnityEngine.Object;

public sealed class UnityViewService : Service, IViewService
{
    private readonly Transform _root;
    private readonly List<IEntityEmitter> _emitterBuffer;
    private readonly List<IEventListener> _eventListenerBuffer;

    public UnityViewService(Contexts contexts) : base(contexts)
    {
        _root = new GameObject("ViewRoot").transform;
        _emitterBuffer = new List<IEntityEmitter>(16);
        _eventListenerBuffer = new List<IEventListener>(16);
    }

    //Can be wired to pooling
    public void LoadAsset(Contexts contexts, GameEntity entity, string asset)
    {

        var viewObject = Object.Instantiate(Resources.Load<GameObject>(string.Format("Prefabs/{0}", asset)), _root);
        if (viewObject == null)
            throw new NullReferenceException(string.Format("Prefabs/{0} not found!", asset));

        var rigidbody = viewObject.GetComponent<IRigidbody>();
        if (rigidbody != null)
            entity.AddRigidbody(rigidbody);

        var view = viewObject.GetComponent<IView>();
        if (view != null)
        {
            view.InitializeView(contexts, entity);
            entity.AddView(view);
        }

        viewObject.GetComponents(_eventListenerBuffer);
        foreach (var listener in _eventListenerBuffer)
            listener.RegisterListeners(entity);
    }

    public void LinkChildsToEntities(Contexts contexts, IView view, IdService idService)
    {
        view.Transform.GetComponentsInChildren(_emitterBuffer);
        foreach (var emitter in _emitterBuffer)
        {
            var e = emitter.Emit();
            e.AddId(idService.GetNext());
            e.AddChildOf(view.Id);
            
            var child = emitter.Transform;
            child.SetParent(_root);
            
            var childView = child.GetComponent<IView>();
            if (childView != null)
            {
                childView.InitializeView(contexts, e);
                e.AddView(childView);
            }
            
            child.GetComponents(_eventListenerBuffer);
            foreach (var listener in _eventListenerBuffer)
                listener.RegisterListeners(e);
        }
    }
}