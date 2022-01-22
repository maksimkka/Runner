using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechingPosition
{
    private float maxPosx = 4f;
    private float minPosx = -4;

    public void CheckPosition(GameObject pos)
    {
        if (pos.transform.position.x > maxPosx)
        {
            pos.transform.position = new Vector3(maxPosx, pos.transform.position.y, pos.transform.position.z);
        }

        else if(pos.transform.position.x < minPosx)
        {
            pos.transform.position = new Vector3(minPosx, pos.transform.position.y, pos.transform.position.z);
        }
    }
}
