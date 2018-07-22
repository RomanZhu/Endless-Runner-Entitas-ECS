using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerTypeListener : MonoBehaviour, IEventListener, IPlayerTypeListener
{
	public Renderer Renderer;

	public string PropertyName = "_EmissionColor";
	[ColorUsage(false, true)]
	public List<Color> Colors = new List<Color>();
	public float  LerpSpeed    = 1f;
    
	private int   _propertyId;
	private Color _targetValue;
	private Color _currentValue;

	private Material _material;

	public void RegisterListeners(IEntity entity)
	{
		_material   = Renderer.material;
		_propertyId = Shader.PropertyToID(PropertyName);

		var state = Contexts.sharedInstance.gameState;
		var e     = state.CreateEntity();
		e.AddPlayerTypeListener(this);
        
		OnPlayerType(state.playerTypeEntity, state.playerType.Value);
	}

	public void OnPlayerType(GameStateEntity entity, int Value)
	{
		_targetValue = Colors[Math.Min(Colors.Count - 1, Value)];
	}

	private void Update()
	{
		_currentValue = Color.Lerp(_currentValue, _targetValue, LerpSpeed * Time.deltaTime);
		_material.SetColor(_propertyId, _currentValue);
	}
}