using Entitas;
using UnityEngine;

public class ApplyJumpListener : MonoBehaviour, IEventListener, IApplyJumpListener, IApplyJumpRemovedListener
{
    public Renderer Renderer;

    public string PropertyName = "_Magnitude";
    public float OnValue = 1f;
    public float OffValue = 0f;
    public float LerpSpeed = 1f;
    
    private int _propertyId;
    private float _targetValue;
    private float _currentValue;

    private Material _material;

    public void RegisterListeners(IEntity entity)
    {
        _material   = Renderer.material;
        _propertyId = Shader.PropertyToID(PropertyName);

        var state = Contexts.sharedInstance.gameState;
        var e     = state.CreateEntity();
        e.AddApplyJumpListener(this);
        e.AddApplyJumpRemovedListener(this);
        
        ApplyJump(state.isApplyJump);
    }

    public void OnApplyJump(GameStateEntity entity)
    {
        ApplyJump(true);
    }

    public void OnApplyJumpRemoved(GameStateEntity entity)
    {
        ApplyJump(false);
    }

    private void ApplyJump(bool value)
    {
        _targetValue = value ? OnValue : OffValue;
    }

    private void Update()
    {
        _currentValue = Mathf.Lerp(_currentValue, _targetValue, LerpSpeed * Time.deltaTime);
        _material.SetFloat(_propertyId, _currentValue);
    }
}