using Unity.Entities;

[GenerateAuthoringComponent]
public struct TemporaryChangeMaterialOnTriggerComponent : IComponentData
{
    public Entity ReferenceEntity;
}
