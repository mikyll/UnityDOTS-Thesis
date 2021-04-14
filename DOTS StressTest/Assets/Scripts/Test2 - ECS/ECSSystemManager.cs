using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;

public class ECSSystemManager : MonoBehaviour
{
    [Header("Settings")]
    public Text ECounter;
    public Text FpsValue;

    private float DeltaTime = 0.0f;
    private float lastInterval;
    private float updateInterval = 0.1f;

    private int spawned = 0;
    private EntityManager EM;

    void Start()
    {
        EM = World.DefaultGameObjectInjectionWorld.EntityManager;
        lastInterval = Time.realtimeSinceStartup; // inizializza l'ultimo intervallo di aggiornamento del valore degli FPS

        //UpdateCount();
    }

    private void Update()
    {
        float timeNow = Time.realtimeSinceStartup;

        if (timeNow > lastInterval + updateInterval)
        {
            // aggiorna la UI
            UpdateFPS();
            lastInterval = timeNow;
        }

        //UpdateCount();
    }


    // update GameObjectCount
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
        string text = string.Format("{0:0.} fps", fps);
        //string text = string.Format("{0:0.0} ms\n{1:0.} fps", msec, fps);

        FpsValue.text = text;
    }
    // https://docs.unity3d.com/ScriptReference/Time-realtimeSinceStartup.html
}

public class EntitySpawnerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        
    }
}