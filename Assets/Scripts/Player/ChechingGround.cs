using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechingGround
{
    private float rayDistance = 10;
    //public bool isGrounded;
    //public bool isGrounded2;
    public float posx = 0;
    public float posy = 1;

    //private void FixedUpdate()
    //{
    //    CheckGroundLeft(transform.position, transform.rotation);
    //}

    public bool CheckGroundLeft(Vector3 position, Quaternion rotation)
    {
        Vector3 leftDirection = new Vector3(rotation.x - posx, rotation.y - posy);

        return CreationRay(position, leftDirection);

    }

    public bool CheckGroundRight(Vector3 position, Quaternion rotation)
    {
        Vector3 rightDirection = new Vector3(rotation.x + posx, rotation.y - posy);

        return CreationRay(position, rightDirection);

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
