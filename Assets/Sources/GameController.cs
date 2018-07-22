using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Contexts           _contexts;
    private FixedUpdateSystems _fixedUpdateSysems;
    private Services           _services;
    private UpdateSystems      _updateSystems;

    [SerializeField]
    private TextAsset _chunkDefinitions;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        _services = new Services();

        Configure(_contexts);
        CreateServices(_contexts, _services);

        _updateSystems = new UpdateSystems(_contexts, _services);
        _fixedUpdateSysems = new FixedUpdateSystems(_contexts, _services);

        _updateSystems.Initialize();
        _fixedUpdateSysems.Initialize();
    }

    private void Update()
    {
        _updateSystems.Execute();
        _updateSystems.Cleanup();
    }

    private void FixedUpdate()
    {
        _fixedUpdateSysems.Execute();
        _fixedUpdateSysems.Cleanup();
    }

    private void OnDestroy()
    {
        _updateSystems.DeactivateReactiveSystems();
        _updateSystems.ClearReactiveSystems();
        _updateSystems.TearDown();

        _fixedUpdateSysems.DeactivateReactiveSystems();
        _fixedUpdateSysems.ClearReactiveSystems();
        _fixedUpdateSysems.TearDown();
    }

    //It's not in the system for ease of use
    private void Configure(Contexts contexts)
    {
        //I would prefer to make it without any "EntityEmitters"..
        //But it would be very time consuming OR hardly customizable
        
        //One way is to look inside prefab for marker components (PlatformMonobehaviour, CoinMonobehaviour..)
        //and parse those objects to JSON data for each chunk
        //When chunk is prepooled - those objects with markers are removed. And when this chunk should be places in
        //world - we pull it from pool AND pull interactible objects from their pools
        //But it would take a day of work, so here I am :D
        contexts.config.SetChunkDefinitions(JsonUtility.FromJson<ChunkDefinitions>(_chunkDefinitions.text));
        contexts.config.SetChunkCreationDistance(200f);
        contexts.config.SetChunkDestructionDistance(50f);

        contexts.config.SetTypeCount(2);
        contexts.config.SetTypeColorTable(new List<Color> {new Color(0.54f, 0.64f, 1f), new Color(1f, 0.6f, 0.54f), new Color(0.75f, 1f, 0.5f)});

        contexts.config.SetJumpImpulse(new Vector2(0f, 18f));
        contexts.config.SetJumpAcceleration(new Vector2(20f, -18f));
        contexts.config.SetJumpMaxVelocity(new Vector2(20f, 45f));

        contexts.config.SetMaxJumpCount(2);
        contexts.config.SetMaxJumpTime(20f);
        contexts.config.SetJumpEndOnStuckTimeout(0.1f);

        contexts.config.SetStandardAcceleration(new Vector2(20f, -6f));
        contexts.config.SetStandardMaxVelocity(new Vector2(20f, 70f));
        contexts.config.SetAdditionalMidAirGravity(-35f);
        
        contexts.config.SetVelocityIncreaseSpeed(80f);
        contexts.config.SetVelocityDecreaseSpeed(2f);
        
        contexts.config.SetStartPlayerPosition(new Vector2(0f, 4f));
        contexts.config.SetPlayerSphereRadius(0.52f);
        contexts.config.SetPlayerRespawnDelay(2f);
        contexts.config.SetDeathHeight(-5f);
    }

    private void CreateServices(Contexts contexts, Services services)
    {
        services.IdService                 = new IdService(contexts);
        services.ViewService               = new UnityViewService(contexts);
        services.InputService              = new UnityInputService(contexts);
        services.TimeService               = new UnityTimeService(contexts);
        services.PhysicsService            = new UnityPhysicsService(contexts);
        services.JumpService               = new JumpService(contexts);
        services.CreatePlayerService       = new CreatePlayerService(contexts);
        services.KillPlayerService         = new KillPlayerService(contexts);
        services.CreateChunkService        = new CreateChunkService(contexts);
        services.CollisionEmisstionService = new UnityCollisionEmissionService(contexts);
    }

#if !ENTITAS_DISABLE_VISUAL_DEBUGGING
    private void OnGUI()
    {
        var state = _contexts.gameState;
        GUILayout.Label((state.isJumping ? "V" : "O") + " Jumping");
        GUILayout.Label((state.isApplyJump ? "V" : "O") + " ApplyJump");
        GUILayout.Label((state.isJumpImpulseFired ? "V" : "O") + " JumpImpulseFired");
        GUILayout.Label((state.isJumpTimedOut ? "V" : "O") + " JumpTimedOut");
        GUILayout.Label((state.isLanded ? "V" : "O") + " Landed");
        GUILayout.Space(20f);
        GUILayout.Label(state.lastJumpTime.Value + " LastJumpTime");
        GUILayout.Label(state.currentJumpCount.Value + " JumpCount");
        GUILayout.Label(state.currentMaxVelocity.Value + " MaxVelocity");
    }
#endif
}