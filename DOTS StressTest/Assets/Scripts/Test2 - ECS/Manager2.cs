using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;
using Unity.Jobs;

// Bootstrap class used to acceess MonoBehaviour while still using ECS as the core of the project.
public class Manager2 : MonoBehaviour
{
    #region Editor Settings

    [Header("UI Objects")]
    public Text ECounter;
    public Text FpsValue;

    [Header("GameObjects")]
    public GameObject EntityPrefab;

    [Header("Settings")]
    public int EntityCount = 20;
    public float SpawnRadius = 8.0f;
    public float3 SpawnCenter = new float3 { x = 0.0f, y = 2.0f, z = 0.0f };
    public float3 RotationSpeed = new float3 { x = 10.0f, y = 50.0f, z = 10.0f };

    #endregion

    private int spawned;
    

    private float DeltaTime = 0.0f;

    EntityManager Manager;
    BeginInitializationEntityCommandBufferSystem CommandBufferSystem;

    GameObjectConversionSettings Settings;
    BlobAssetStore BlobStore;

    private void Start()
    {
        Manager = World.DefaultGameObjectInjectionWorld.EntityManager;

        BlobStore = new BlobAssetStore();
        Settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, BlobStore);

        CommandBufferSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        
        // Create ScoreBoxes on level start
        AddScoreBoxes();
    }

    private void OnApplicationQuit()
    {
        BlobStore.Dispose();
    }

    private void Update()
    {
        UpdateCount();
        UpdateFPS();
    }


    // update EntityCount
    private void UpdateCount()
    {
        DeltaTime += (Time.unscaledDeltaTime - DeltaTime) * 0.1f;

        string text = string.Format("E counter: {0:d}", spawned);

        ECounter.text = text;
    }
    // Simple FPS display from Unity sample page
    private void UpdateFPS()
    {
        DeltaTime += (Time.unscaledDeltaTime - DeltaTime) * 0.1f;

        float msec = DeltaTime * 1000.0f;
        float fps = 1.0f / DeltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);

        FpsValue.text = text;
    }

    // Create the ScoreBox entities and assign the corresponding components
    private void AddScoreBoxes()
    {
        // Create Entity Command Buffer for parallel writing
        var commandBuffer = CommandBufferSystem.CreateCommandBuffer().AsParallelWriter();
        NativeArray<Entity> entities = new NativeArray<Entity>(EntityCount, Allocator.TempJob);

        // Convert our ScoreBox GameObject Prefab into an Entity prefab
        Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(EntityPrefab, Settings);
        Manager.Instantiate(prefab, entities);

        spawned += entities.Length;

        // Generate Random with default seed
        var generator = new Unity.Mathematics.Random((uint)System.DateTime.Now.ToBinary());
        
        // Create the SpawnerJob to randomly spawn ScoreBox entities
        var spawnerJob = new SpawnerJob()
        {
            CommandBuffer = commandBuffer,
            Entities = entities,
            Generator = generator,
            spawnRadius = SpawnRadius,
            RSpeed = RotationSpeed,
            spawnCenter = SpawnCenter
        };

        // Schedule the job to run in parallel
        JobHandle spawnerJobHandle = new JobHandle();
        JobHandle sheduleParralelJobHandle = spawnerJob.ScheduleParallel(entities.Length, 64, spawnerJobHandle);
        
        // Ensure the job is completed
        sheduleParralelJobHandle.Complete();

        entities.Dispose();
    }
}

// Define the SpawnerJob to spawn ScoreBox entities
struct SpawnerJob : IJobFor
{
    [WriteOnly]
    public EntityCommandBuffer.ParallelWriter CommandBuffer;
    [ReadOnly]
    public NativeArray<Entity> Entities;
    [ReadOnly]
    public Unity.Mathematics.Random Generator;
    [ReadOnly]
    public float3 RSpeed;
    [ReadOnly]
    public float3 spawnCenter;
    [ReadOnly]
    public float spawnRadius;

    // Generate a random spawn point on a circle
    private float3 GenerateBoxSpawn(float radius)
    {
        //Vector3 origin = new Vector3(0.0f, 0.5f, 0.0f);

        float angle = Generator.NextFloat(0.0f, 1.0f) * 360.0f;
        float3 spawnPos = float3.zero;
        float randomRadius = Generator.NextFloat(0.0f, radius);


        spawnPos.x = spawnCenter.x + randomRadius * math.sin(math.radians(angle));
        spawnPos.y = spawnCenter.y;
        spawnPos.z = spawnCenter.z + randomRadius * math.cos(math.radians(angle));

        return spawnPos;
    }

    public void Execute(int i)
    {
        // Randomly generate a score value for each ScoreBox
        int score = Generator.NextInt(1, 3);
        
        // Assign the points per ScoreBox and it's position on the spawn circle
        CommandBuffer.AddComponent(i, Entities[i], new RotateComponent { speed = RSpeed });
        CommandBuffer.SetComponent(i, Entities[i], new Translation { Value = GenerateBoxSpawn(spawnRadius) });
    }}

