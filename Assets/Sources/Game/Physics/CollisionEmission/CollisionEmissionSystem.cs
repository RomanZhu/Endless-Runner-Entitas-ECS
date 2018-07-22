using Entitas;
using UnityEngine;

public sealed class CollisionEmissionSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IPhysicsService _physicsService;
    private readonly ICollisionEmisstionService _collisionEmisstionService;
    
    private readonly RaycastHit[] _buffer = new RaycastHit[16];
    
    public CollisionEmissionSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _physicsService            = services.PhysicsService;
        _collisionEmisstionService = services.CollisionEmisstionService;
    }
    
    public void Execute()
    {
        var player = _contexts.game.playerEntity;
        if (player != null && player.hasPosition && !player.isDead)
        {
            var radius = _contexts.config.playerSphereRadius.Value;
            var hitCount = _physicsService.SphereCast(player.position.Value, radius, _buffer, 1<<8);

            for (int i = 0; i < hitCount; i++)
            {
                var hit = _buffer[i];
                _collisionEmisstionService.Emit(hit);
            }
        }
    }
}