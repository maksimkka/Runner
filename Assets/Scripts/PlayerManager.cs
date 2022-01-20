using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float slidingSmoothness;
    [SerializeField] private GameObject leftRay;
    [SerializeField] private GameObject rightRay;
    [SerializeField] private GameState gameState;

    private IGameOver gameOver;
    private Rigidbody playerRb;
    private PlayerMove playerMove;
    private MoveInput inputActions;
    private ChechingGround chectingGround;
    private ChechingPosition chechingPosition;

    public bool isGroundedLeft;
    public bool isGroundedRight;

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Awake()
    {
        GetObjects();
    }

    private void Update()
    {
        isGroundedLeft = chectingGround.CheckGroundLeft(leftRay.transform.position, leftRay.transform.rotation);
        isGroundedRight = chectingGround.CheckGroundRight(rightRay.transform.position, rightRay.transform.rotation);
        chechingPosition.CheckPosition(gameObject);
    } 

    private void FixedUpdate()
    {

        playerMove.Move(playerRb, speed);

        if (isGroundedLeft)
        {
            playerMove.LeftSliding(playerRb, inputActions, slidingSmoothness);
        }

        if (isGroundedRight)
        {
            playerMove.RightSliding(playerRb, inputActions, slidingSmoothness);
        }
    }

    private void GetObjects()
    {
        gameOver = gameState.GetComponent<IGameOver>();
        playerRb = GetComponent<Rigidbody>();
        playerMove = new PlayerMove();
        chectingGround = new ChechingGround();
        chechingPosition = new ChechingPosition();
        inputActions = new MoveInput();
    }

    private void OnTriggerEnter(Collider other)
    {
        //GameObject obstacle = other.gameObject;

        if (other.gameObject.CompareTag("obstacle"))
        {
            gameOver.GameOver();
        }
    }
}
