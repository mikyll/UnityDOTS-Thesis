using Unity.Entities;

[GenerateAuthoringComponent]
public struct PersistentChangeMaterialOnTriggerComponent : IComponentData
{
    public Entity ReferenceEntity;
}
