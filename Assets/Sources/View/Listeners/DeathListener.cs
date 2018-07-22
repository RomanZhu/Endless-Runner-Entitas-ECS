using Entitas;
using UnityEngine;

public class DeathListener : MonoBehaviour, IEventListener, IDeadListener
{
    public GameObject EffectPrefab;

    public void RegisterListeners(IEntity entity)
    {
        var player = (GameEntity) entity;
        player.AddDeadListener(this);
    }

    public void OnDead(GameEntity entity)
    {
        var go = Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        Destroy(go, 5f);
    }
}