using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float slidingSmoothness;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject leftRay;
    [SerializeField] private GameObject rightRay;

    private bool isGroundedLeft;
    private bool isGroundedRight;
    private ChechingGround chectingGround;
    private CharacterController characterController;

    Vector2 sideInputs;
    Vector3 moveForvard;
    Vector3 sideMovement;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        chectingGround = new ChechingGround();
    }

    private void Update()
    {
        isGroundedLeft = chectingGround.CheckGround(leftRay.transform.position, leftRay.transform.rotation);
        isGroundedRight = chectingGround.CheckGround(rightRay.transform.position, rightRay.transform.rotation);
        
    }

    private void FixedUpdate()
    {
        MoveDir();
    }

    public void ReceiveInput(Vector2 sideInput)
    {
        sideInputs = sideInput;
    }

    private void MoveForvard()
    {
        moveForvard = gameObject.transform.forward * speed;
    }

    private void LeftSliding()
    {
        if (sideInputs.x < 0 && isGroundedLeft)
        {
            sideMovement = gameObject.transform.right * sideInputs.x * slidingSmoothness;
        }

        else if (sideInputs.x > 0 && isGroundedRight)
        {
            sideMovement = gameObject.transform.right * sideInputs.x * slidingSmoothness;
        }

        else
        {
            sideMovement = new Vector3(0, 0, 0);
        }    
    }

    public void MoveDir()
    {
        MoveForvard();
        LeftSliding();
        characterController.Move(moveForvard * Time.deltaTime);
        characterController.Move(sideMovement * Time.deltaTime);
    }
}
