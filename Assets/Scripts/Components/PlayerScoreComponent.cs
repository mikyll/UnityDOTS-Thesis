using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;

[GenerateAuthoringComponent]
public struct PlayerScoreComponent : IComponentData
{
    //public FixedString32 nickname;
    public float score;
    //public Entity bonusPrefabEntity;
}
