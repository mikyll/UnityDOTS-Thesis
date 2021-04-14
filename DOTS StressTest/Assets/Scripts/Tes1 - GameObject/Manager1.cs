using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Manager1 : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject prefabToSpawn;

    [Header("Settings")]
    public float spawnRadius = 10.0f;
    public Vector3 spawnCenter = new Vector3() { x = 0.0f, y = 0.0f, z = 0.0f };
    public int spawnCount = 0;
    public int spawnOnClick = 1;

    private Unity.Mathematics.Random Generator;

    private int spawned;

    [Header("UI Objects")]
    public Text GOCounter;
    public Text FpsValue;
    private float DeltaTime = 0.0f;
    private float lastInterval;
    private float updateInterval = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        spawned = 0;
        // genera Random con un seed pseudorandomico preso dal time del sistema
        Generator = new Unity.Mathematics.Random((uint)System.DateTime.Now.ToBinary());

        lastInterval = Time.realtimeSinceStartup;

        SpawnPrefab(spawnCount);
    }

    private void Update()
    {
        float timeNow = Time.realtimeSinceStartup;

        // se si preme "spazio" spawna spawnOnClick GameObject
        if (Input.GetKeyDown("space"))
        {
            SpawnPrefab(spawnOnClick);
        }

        if (timeNow > lastInterval + updateInterval)
        {
            // aggiorna la UI
            UpdateFPS();
            lastInterval = timeNow;
        }
    }

    // genera una posizione di spawn per il GameObject
    private float3 GenerateSpawnPosition()
    {
        //Vector3 origin = new Vector3(0.0f, 0.5f, 0.0f);
        
        float3 spawnPosition = float3.zero;

        float angle = Generator.NextFloat(0.0f, 1.0f) * 360.0f;
        float randomRadius = Generator.NextFloat(0.0f, spawnRadius);

        spawnPosition.x = spawnCenter.x + randomRadius * math.sin(math.radians(angle));
        spawnPosition.y = spawnCenter.y;
        spawnPosition.z = spawnCenter.z + randomRadius * math.cos(math.radians(angle));

        return spawnPosition;
    }

    private void SpawnPrefab(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(prefabToSpawn, GenerateSpawnPosition(), transform.rotation);
            spawned++;
        }
        UpdateCount();
    }

    // update GameObjectCount
    private void UpdateCount()
    {
        DeltaTime += (Time.unscaledDeltaTime - DeltaTime) * 0.1f;

        string text = string.Format("GO counter: {0:d}", spawned);

        GOCounter.text = text;
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
    // https://docs.unity3d.com/ScriptReference/Time-realtimeSinceStartup.html
}



/*public struct IntBufferElement : IBufferElementData
{
    public int value;
}*/
/*// TEST DynamicBuffer
        EntityManager em = World.DefaultGameObjectInjectionWorld.EntityManager;
        Entity e = em.CreateEntity();
        em.Instantiate(e);
        DynamicBuffer<IntBufferElement> db = em.AddBuffer<IntBufferElement>(e);
        db.Add(new IntBufferElement() { value = 1 });
        DynamicBuffer<int> db2 = db.Reinterpret<int>();
        db2.Add(3);*/


/*private void Spawn()
{
    var randomPos = (Vector3)UnityEngine.Random.insideUnitCircle * 10;
    randomPos += transform.position;
    Instantiate(prefabToSpawn, randomPos, transform.rotation);
}*/
