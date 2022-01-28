using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerMove movement;
    private MoveInput controls;
    MoveInput.GroundMovementActions groundMovement;

    Vector2 sideInput; 

    private void Awake()
    {
        movement = gameObject.GetComponent<PlayerMove>();
        controls = new MoveInput();
        groundMovement = controls.GroundMovement;
        groundMovement.Move.performed += context => sideInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        movement.ReceiveInput(sideInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
