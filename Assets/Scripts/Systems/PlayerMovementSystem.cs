using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.NetCode;
using Unity.Transforms;
using Unity.Physics;

[UpdateInGroup(typeof(GhostPredictionSystemGroup))]
public class PlayerMovementSystem : SystemBase
{
    GhostPredictionSystemGroup m_GhostPredictionSystemGroup;
    protected override void OnCreate()
    {
        m_GhostPredictionSystemGroup = World.GetExistingSystem<GhostPredictionSystemGroup>();
        
    }
    protected override void OnUpdate() 
    {
        var tick = m_GhostPredictionSystemGroup.PredictingTick;
        var deltaTime = Time.DeltaTime;
        Entities.ForEach((DynamicBuffer<PlayerInput> inputBuffer, ref Translation trans, ref PhysicsVelocity pv, in PredictedGhostComponent prediction, in PlayerMovementSpeed pms) =>
        {
            if (!GhostPredictionSystemGroup.ShouldPredict(tick, prediction))
                return;
            PlayerInput input;
            inputBuffer.GetDataAtTick(tick, out input);
            var speed = pms.speed;
            /*if (input.horizontal > 0)
                trans.Value.x += speed * deltaTime;
            if (input.horizontal < 0)
                trans.Value.x -= speed * deltaTime;
            if (input.vertical > 0)
                trans.Value.z += speed * deltaTime;
            if (input.vertical < 0)
                trans.Value.z -= speed * deltaTime;*/
            
            // cosi' non rimbalza ma lagga e ci mette un po' ad accelerare
            if (input.horizontal > 0)
                pv.Linear.x += speed * deltaTime;
            if (input.horizontal < 0)
                pv.Linear.x -= speed * deltaTime;
            if (input.vertical > 0)
                pv.Linear.z += speed * deltaTime;
            if (input.vertical < 0)
                pv.Linear.z -= speed * deltaTime;

            if (input.firstJump)
            {
                pv.Linear.y = 8f;
                input.firstJump = false;
            }

            /*
             * un altro modo per far muovere l'oggetto è generando un impulso lineare (using Unity.Physics.Extensions):
             * Itero su tutte le entities che hanno i componenti PhysicsVelocity e PhysicsMass (+ PlayerMovementSpeed
             * e l'input del Player, nel nostro caso DynamicBuffer<PlayerInput>), quindi imposto la direzione
             * dell'impulso con:
             * float3 direction = new float3(horizontalInput, 0.0f, verticalInput);
             * e applico l'impulso lineare utilizzando il metodo seguente:
             * PhysicsComponentExtensions.ApplyLinearImpulse(ref velocity, physicsMass, direction * movement.Force 
             */

        }).ScheduleParallel();
    }
}
