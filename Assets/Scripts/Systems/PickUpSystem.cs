using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics.Stateful;
using Unity.Rendering;
using Unity.NetCode;
using System;

[UpdateInGroup(typeof(ClientAndServerSimulationSystemGroup))]
public class PickUpSystem : SystemBase
{
    private EndFixedStepSimulationEntityCommandBufferSystem m_CommandBufferSystem;
    private TriggerEventConversionSystem m_TriggerSystem;
    private EntityQueryMask m_NonTriggerMask;

    protected override void OnCreate()
    {
        m_CommandBufferSystem = World.GetOrCreateSystem<EndFixedStepSimulationEntityCommandBufferSystem>();
        m_TriggerSystem = World.GetOrCreateSystem<TriggerEventConversionSystem>();
        m_NonTriggerMask = EntityManager.GetEntityQueryMask(
            GetEntityQuery(new EntityQueryDesc
            {
                None = new ComponentType[]
                {
                    typeof(StatefulTriggerEvent)
                }
            })
        );
        RequireForUpdate(GetEntityQuery(new EntityQueryDesc
        {
            All = new ComponentType[]
            {
                typeof(CollectibleTagComponent)
            }
        }));
    }

    protected override void OnUpdate()
    {
        Dependency = JobHandle.CombineDependencies(m_TriggerSystem.OutDependency, Dependency);

        var commandBuffer = m_CommandBufferSystem.CreateCommandBuffer();

        // Need this extra variable here so that it can
        // be captured by Entities.ForEach loop below
        var nonTriggerMask = m_NonTriggerMask;


        Entities
            .WithName("PickUpOnTriggerEnter")
            .WithoutBurst()
            .ForEach((Entity e, ref DynamicBuffer<StatefulTriggerEvent> triggerEventBuffer, ref CollectibleTagComponent collectibleComponent) =>
            {
                for (int i = 0; i < triggerEventBuffer.Length; i++)
                {
                    var triggerEvent = triggerEventBuffer[i]; // l'entity dell'oggetto collectible
                    var otherEntity = triggerEvent.GetOtherEntity(e); // l'oggetto dinamico che vi collide

                    // exclude other triggers and processed events
                    if (triggerEvent.State == EventOverlapState.Stay || !nonTriggerMask.Matches(otherEntity))
                    {
                        continue;
                    }

                    if (triggerEvent.State == EventOverlapState.Enter && EntityManager.HasComponent<PlayerMovementSpeed>(otherEntity))
                    {
                        var punteggioPlayer = EntityManager.GetComponentData<PlayerScoreComponent>(otherEntity);
                        punteggioPlayer.score += collectibleComponent.points;

                        var ghostId = EntityManager.GetComponentData<GhostComponent>(otherEntity).ghostId;
                        // printa due volte perche' viene eseguito sulle simulazioni di client e su server
                        UnityEngine.Debug.Log(String.Format("Il player " + ghostId + " ha raccolto " + collectibleComponent.points + " punti. Tot punti player " + ghostId + ": " + punteggioPlayer.score));

                        // var deleteTag = new DeleteTagComponent();

                        // assolutamente necessari
                        commandBuffer.SetComponent(otherEntity, punteggioPlayer);
                        commandBuffer.AddComponent<DeleteTagComponent>(e, new DeleteTagComponent());
                    }
                }
            }).Run();

        m_CommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
