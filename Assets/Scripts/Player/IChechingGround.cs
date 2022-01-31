using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChechingGround 
{
    public bool GroundCheck(Transform pos, LayerMask groundMask);

    public bool SideGroundCheck(Vector3 position, Quaternion rotation);
}