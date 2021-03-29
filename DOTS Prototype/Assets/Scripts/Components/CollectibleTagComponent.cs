using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

// questo componente viene assegnato dallo spawner a tutte le entities che possono essere raccolte dal/dai Player
[GenerateAuthoringComponent]
public struct CollectibleTagComponent : IComponentData
{
    public float points;
}
