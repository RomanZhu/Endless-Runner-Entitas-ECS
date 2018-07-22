using UnityEngine;

public class UnityView : MonoBehaviour, IView, IDestroyedListener
{
    private GameObject _gameObject;
    private Transform _transform;
    private GameEntity _entity;

    public void InitializeView(Contexts contexts, GameEntity entity)
    {
        _gameObject = gameObject;
        _transform = transform;
        _entity = entity;
        _entity.AddDestroyedListener(this);

        Id = _entity.id.Value;

#if UNITY_EDITOR
        //gameObject.Link(_entity, contexts.game);
#endif
    }

    public void OnDestroyed(GameEntity entity)
    {
#if UNITY_EDITOR
        //gameObject.Unlink();
#endif
        Destroy(gameObject);
    }
    
    #region IView implementation
    public int Id { get; set; }
    
    public bool Enabled
    {
        get
        {
            return _gameObject.activeSelf;
        }
        set
        {
            _gameObject.SetActive(value);
        }
    }
    
    public Vector2 Position
    {
        get { return _transform.position;}
        set { _transform.position = value; }
    }
    
    public Transform Transform
    {
        get { return _transform; }
    }
    #endregion
}