using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics.Stateful;
using Unity.Rendering;
using UnityEngine;
using Unity.NetCode;

[UpdateInGroup(typeof(ClientAndServerSimulationSystemGroup))]
public class PersistentChangeMaterialOnTriggerSystem : SystemBase
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
                typeof(PersistentChangeMaterialOnTriggerComponent)
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
            .WithName("ChangeMaterialOnTriggerEnter")
            .WithoutBurst()
            .ForEach((Entity e, ref DynamicBuffer<StatefulTriggerEvent> triggerEventBuffer, ref PersistentChangeMaterialOnTriggerComponent changeMaterial) =>
            {
                for (int i = 0; i < triggerEventBuffer.Length; i++)
                {
                    var triggerEvent = triggerEventBuffer[i];
                    var otherEntity = triggerEvent.GetOtherEntity(e);

                    // exclude other triggers and processed events
                    if (triggerEvent.State == EventOverlapState.Stay || !nonTriggerMask.Matches(otherEntity))
                    {
                        continue;
                    }

                    // l'entity entra nel portale (trigger contatto fra entity dinamica e superficie portale statica)
                    if (triggerEvent.State == EventOverlapState.Enter)
                    {
                        var volumeRenderMesh = EntityManager.GetSharedComponentData<RenderMesh>(e);
                        var overlappingRenderMesh = EntityManager.GetSharedComponentData<RenderMesh>(otherEntity);
                        overlappingRenderMesh.material = volumeRenderMesh.material;

                        commandBuffer.SetSharedComponent(otherEntity, overlappingRenderMesh);
                    }
                }
            }).Run();

        m_CommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
