using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerCameraFollowComponent : IComponentData
{
    public bool fixedCamera;
    public float xOffset;
    public float yOffset;
    public float zOffset;
}
