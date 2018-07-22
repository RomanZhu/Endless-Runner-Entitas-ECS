using UnityEngine;

public class DeathHeightListener : MonoBehaviour, IDeathHeightListener, IPositionListener
{
    private Transform _transform;
    private float _height;

    private void Start()
    {
        _transform = transform;
        var deathHeight = Contexts.sharedInstance.config.deathHeightEntity;
        deathHeight.AddDeathHeightListener(this);

        var player = Contexts.sharedInstance.game.playerEntity;
        player.AddPositionListener(this);
        
        OnDeathHeight(deathHeight, deathHeight.deathHeight.Value);
        OnPosition(player, player.position.Value);
    }

    private void OnDestroy()
    {
        Contexts.sharedInstance.config.deathHeightEntity.RemoveDeathHeightListener(this);
        Contexts.sharedInstance.game.playerEntity.RemovePositionListener(this);
    }

    public void OnDeathHeight(ConfigEntity entity, float Value)
    {
        _height = Value;
        _transform.position = new Vector2(transform.position.x, _height);
    }

    public void OnPosition(GameEntity entity, Vector2 Value)
    {
        _transform.position = new Vector2(Value.x, _height);
    }
}