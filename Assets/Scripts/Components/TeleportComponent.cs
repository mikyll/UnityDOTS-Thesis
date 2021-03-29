using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;
using Unity.Physics.Stateful;
using Unity.Physics.Systems;
using Unity.Transforms;
using UnityEngine;

[GenerateAuthoringComponent]
public struct TeleportComponent : IComponentData
{
    public Entity Companion;

    // When an entity is teleported to it's companion,
    // we increase companion's TransferCount so that
    // the enitty doesn't get immediately teleported
    // back to the original portal
    public int TransferCount;
}

/*
// Codice del TriggerTeleport preso dal sample di Unity Physics: viene implementato manualmente il metodo che converte
// il GameObject
public class TeleportComponentAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public PhysicsBodyAuthoring CompanionPortal;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var companion = conversionSystem.GetPrimaryEntity(CompanionPortal);
        dstManager.AddComponentData(entity, new TeleportComponent
        {
            Companion = companion,
            TransferCount = 0
        });
    }
}*/
