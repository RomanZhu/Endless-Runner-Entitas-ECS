using Entitas;
using UnityEngine;

public class ColorListener : MonoBehaviour, IEventListener, IColorListener
{
	[SerializeField] private Renderer _renderer;
	
	public void RegisterListeners(IEntity entity)
	{
		var e = (GameEntity) entity;
		e.AddColorListener(this);
		
		if (e.hasColor)
		{
			OnColor(e, e.color.Value);
		}
	}

	public void OnColor(GameEntity entity, Color Value)
	{
		_renderer.material.color = Value;
	}
}
