using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.NetCode;

[UpdateInGroup(typeof(ClientAndServerSimulationSystemGroup))]
public class DeleteCollectibleSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityCommandBuffer commandBuffer = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

        Entities
            .WithAll<DeleteTagComponent>()
            .ForEach((Entity entity) =>
            {
                commandBuffer.DestroyEntity(entity);
            }).Run();

        commandBuffer.Playback(EntityManager);
        commandBuffer.Dispose();
    }
}
