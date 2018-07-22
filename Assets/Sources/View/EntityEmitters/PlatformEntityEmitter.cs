using UnityEngine;

public class PlatformEntityEmitter : MonoBehaviour, IEntityEmitter
{    
    public bool RandomizeType = true;
    public int Type;

    public Transform Transform
    {
        get { return transform; }
    }

    public GameEntity Emit()
    {
        var entity = Contexts.sharedInstance.game.CreateEntity();

        entity.isPlatform = true;
        entity.isRandomizePlatformType = RandomizeType;
        entity.AddPlatformType(Type);

        return entity;
    }
}