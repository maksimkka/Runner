using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove
{
    public void Move(Rigidbody playerRb, float speed)
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, speed);
    }

    public void LeftSliding(Rigidbody playerRb, MoveInput inputActions, float slidingSmoothness)
    {
        float slideVector = inputActions.Player.Move.ReadValue<float>();
        if (slideVector < 0)
        {
            playerRb.velocity = new Vector3(slidingSmoothness * slideVector, playerRb.velocity.y, playerRb.velocity.z);
        }
    }

    public void RightSliding(Rigidbody playerRb, MoveInput inputActions, float slidingSmoothness)
    {
        float slideVector = inputActions.Player.Move.ReadValue<float>();
        if (slideVector > 0)
        {
            playerRb.velocity = new Vector3(slidingSmoothness * slideVector, playerRb.velocity.y, playerRb.velocity.z);
        }
    }
}
