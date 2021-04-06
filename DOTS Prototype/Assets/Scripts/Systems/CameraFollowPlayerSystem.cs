using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.NetCode;
using Unity.Transforms;
using Unity.Physics;
using Unity.Physics.Systems;

[UpdateInGroup(typeof(ClientSimulationSystemGroup))]
[UpdateAfter(typeof(EndFramePhysicsSystem))]
public class CameraFollowPlayerSystem : SystemBase
{
    
    protected override void OnUpdate()
    {
        // Camera position default.
        var position = Camera.main.transform.position;

        // Get the player entity.
        var commandTargetComponentEntity = GetSingletonEntity<CommandTargetComponent>();
        var commandTargetComponent = GetComponent<CommandTargetComponent>(commandTargetComponentEntity);

        Entities.WithAll<PlayerScoreComponent>().ForEach((Entity entity, in Translation translation, in PlayerCameraFollowComponent pcf) =>
        {
            // Only update when the player is the one that is controlled by the client's player.
            if (entity == commandTargetComponent.targetEntity && !pcf.fixedCamera)
            {
                position.x = translation.Value.x + pcf.xOffset;
                position.y = translation.Value.y + pcf.yOffset;
                position.z = translation.Value.z + pcf.zOffset;
            }
            // aggiungere che se fixed è enabled la camera sta sempre in un punto (vedere attuale transform)
            // + aggiungere comando per mettere camera libera o no!

        }).Run();

        Camera.main.transform.position = position;
    }
}
