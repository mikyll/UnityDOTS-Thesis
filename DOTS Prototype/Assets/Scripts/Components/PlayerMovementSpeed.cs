using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.NetCode;

[GenerateAuthoringComponent]
public struct PlayerMovementSpeed : IComponentData
{
    //public int PlayerId;
    // questo attributo non e' strettamente necessario
    [GhostField] public float speed;
}
