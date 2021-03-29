using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.NetCode;

[UpdateInGroup(typeof(ClientAndServerSimulationSystemGroup))]
public class FloatingCollectibleSystem : SystemBase
{

    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        float speedX = 10, speedY = 50, speedZ = 10;

        Entities.WithAll<CollectibleTagComponent>().ForEach((ref Rotation rotation) =>
        {
            rotation.Value = math.mul(rotation.Value, quaternion.RotateX(math.radians(speedX * deltaTime)));
            rotation.Value = math.mul(rotation.Value, quaternion.RotateY(math.radians(speedY * deltaTime)));
            rotation.Value = math.mul(rotation.Value, quaternion.RotateZ(math.radians(speedZ * deltaTime)));
        }).Run();
    }
}
