using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechingGround
{
    private float rayDistance = 10;

    private float posy = 1;

    public bool CheckGround(Vector3 position, Quaternion rotation)
    {
        Vector3 leftDirection = new Vector3(rotation.x, rotation.y - posy);

        return CreationRay(position, leftDirection);

    }

    private bool CreationRay(Vector3 position, Vector3 direction)
    {
        bool isGround;
        if (Physics.Raycast(position, direction, Mathf.Infinity))
        {
            Debug.DrawRay(position, direction * rayDistance, Color.yellow);
            isGround = true;
        }

        else
        {
            Debug.DrawRay(position, direction * rayDistance, Color.white);
            isGround = false;
        }

        return isGround;
    }

}
