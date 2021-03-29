using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;
using Unity.Physics.Stateful;
using Unity.Physics.Systems;
using Unity.Transforms;
using UnityEngine;
using Unity.NetCode;

[UpdateInGroup(typeof(ClientAndServerSimulationSystemGroup))]
public class TeleportSystem : SystemBase
{
    private ExportPhysicsWorld m_ExportPhysicsWorld;
    private TriggerEventConversionSystem m_TriggerSystem;
    private EndFramePhysicsSystem m_EndFramePhysicsSystem;

    private EntityQueryMask m_HierarchyChildMask;
    private EntityQueryMask m_NonTriggerDynamicBodyMask;

    protected override void OnCreate()
    {
        m_ExportPhysicsWorld = World.GetOrCreateSystem<ExportPhysicsWorld>();
        m_TriggerSystem = World.GetOrCreateSystem<TriggerEventConversionSystem>();
        m_EndFramePhysicsSystem = World.GetOrCreateSystem<EndFramePhysicsSystem>();

        m_HierarchyChildMask = EntityManager.GetEntityQueryMask(
            GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    typeof(Parent),
                    typeof(LocalToWorld)
                }
            })
        );
        m_NonTriggerDynamicBodyMask = EntityManager.GetEntityQueryMask(
            GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    typeof(Translation),
                    typeof(Rotation),
                    typeof(PhysicsVelocity)
                },
                None = new ComponentType[]
                {
                    typeof(StatefulTriggerEvent)
                }
            })
        );

        Entities.ForEach((ref TeleportComponent tc) =>
        {
            tc.TransferCount = 0;
        }).Run();
    }

    protected override void OnUpdate()
    {
        Dependency = JobHandle.CombineDependencies(m_ExportPhysicsWorld.GetOutputDependency(), Dependency);
        Dependency = JobHandle.CombineDependencies(m_TriggerSystem.OutDependency, Dependency);

        var deltaTime = Time.DeltaTime;

        // Need extra variables here so that they can be
        // captured by the Entities.Foreach loop below
        var hierarchyChildMask = m_HierarchyChildMask;
        var nonTriggerDynamicBodyMask = m_NonTriggerDynamicBodyMask;

        Entities
            .WithName("TriggerVolumePortalJob")
            .WithBurst()
            .WithAll<TeleportComponent>()
            .ForEach((Entity portalEntity, ref DynamicBuffer<StatefulTriggerEvent> triggerBuffer) =>
            {
                var teleportComponent = GetComponent<TeleportComponent>(portalEntity);
                var companionEntity = teleportComponent.Companion;
                var companionTeleportComponent = GetComponent<TeleportComponent>(companionEntity);

                for (int i = 0; i < triggerBuffer.Length; i++)
                {
                    var triggerEvent = triggerBuffer[i];
                    var otherEntity = triggerEvent.GetOtherEntity(portalEntity);

                    // exclude other triggers, static bodies and processed events
                    if (triggerEvent.State != EventOverlapState.Enter || !nonTriggerDynamicBodyMask.Matches(otherEntity))
                    {
                        continue;
                    }

                    // Check if entity just teleported to this portal,
                    // and if it did, decrement TransferCount
                    if (teleportComponent.TransferCount != 0)
                    {
                        teleportComponent.TransferCount--;
                        continue;
                    }

                    // a static body may be in a hierarchy, in which case Translation and Rotation may not be in world space
                    var portalTransform = hierarchyChildMask.Matches(portalEntity)
                        ? Math.DecomposeRigidBodyTransform(GetComponent<LocalToWorld>(portalEntity).Value)
                        : new RigidTransform(GetComponent<Rotation>(portalEntity).Value, GetComponent<Translation>(portalEntity).Value);
                    var companionTransform = hierarchyChildMask.Matches(companionEntity)
                        ? Math.DecomposeRigidBodyTransform(GetComponent<LocalToWorld>(companionEntity).Value)
                        : new RigidTransform(GetComponent<Rotation>(companionEntity).Value, GetComponent<Translation>(companionEntity).Value);

                    var portalPositionOffset = companionTransform.pos - portalTransform.pos;
                    var portalRotationOffset = math.mul(companionTransform.rot, math.inverse(portalTransform.rot));

                    var entityPositionComponent = GetComponent<Translation>(otherEntity);
                    var entityRotationComponent = GetComponent<Rotation>(otherEntity);
                    var entityVelocityComponent = GetComponent<PhysicsVelocity>(otherEntity);

                    entityVelocityComponent.Linear = math.rotate(portalRotationOffset, entityVelocityComponent.Linear);
                    entityPositionComponent.Value += portalPositionOffset;
                    entityRotationComponent.Value = math.mul(entityRotationComponent.Value, portalRotationOffset);

                    SetComponent(otherEntity, entityPositionComponent);
                    SetComponent(otherEntity, entityRotationComponent);
                    SetComponent(otherEntity, entityVelocityComponent);
                    companionTeleportComponent.TransferCount++;
                }

                SetComponent(portalEntity, teleportComponent);
                SetComponent(companionEntity, companionTeleportComponent);
            }).Schedule();
        m_EndFramePhysicsSystem.AddInputDependency(Dependency);
    }
}
