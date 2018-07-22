using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour, IPlayerListener, IPositionListener
{
	[SerializeField] private Transform _target;

	void Start()
	{
		Contexts.sharedInstance.game.CreateEntity().AddPlayerListener(this);
	}

	public void OnPlayer(GameEntity entity)
	{
		entity.AddPositionListener(this);
	}

	public void OnPosition(GameEntity entity, Vector2 Value)
	{
		_target.position = Value;
	}
}
