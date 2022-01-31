using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float slidingSpeed;
    [SerializeField] private float gravity;

    [SerializeField] private GameObject leftRay;
    [SerializeField] private GameObject rightRay;
    [SerializeField] private LayerMask groundMask;

    private bool isGrounded;
    private bool isGroundedLeft;
    private bool isGroundedRight;

    private IChechingGround chectingGround;
    private CharacterController controller;

    private Vector2 sideInputs;
    private Vector3 moveForvard;
    private Vector3 sideMovement;
    private Vector3 velocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        chectingGround = new ChechingGround();
    }

    private void Update()
    {
        isGroundedLeft = chectingGround.SideGroundCheck(leftRay.transform.position, leftRay.transform.rotation);
        isGroundedRight = chectingGround.SideGroundCheck(rightRay.transform.position, rightRay.transform.rotation);

        Gravitation();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void ReceiveInput(Vector2 sideInput)
    {
        sideInputs = sideInput;
    }

    private void MoveForvard()
    {
        moveForvard = gameObject.transform.forward * speed;
    }

    private void Sliding()
    {
        if (sideInputs.x < 0 && isGroundedLeft)
        {
            sideMovement = gameObject.transform.right * sideInputs.x * slidingSpeed;
        }

        else if (sideInputs.x > 0 && isGroundedRight)
        {
            sideMovement = gameObject.transform.right * sideInputs.x * slidingSpeed;
        }

        else
        {
            sideMovement = new Vector3(0, 0, 0);
        }    
    }

    private void Gravitation()
    {
        isGrounded = chectingGround.GroundCheck(gameObject.transform, groundMask);

        if (isGrounded)
        {
            velocity.y = 0;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void Movement()
    {
        MoveForvard();
        Sliding();
        controller.Move(moveForvard * Time.deltaTime);
        controller.Move(sideMovement * Time.deltaTime);
    }
}
