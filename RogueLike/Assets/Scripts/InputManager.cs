using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private AnimatorManager animatorManager;

    public Vector2 movementInput;
    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animatorManager = GetComponent<AnimatorManager>();
    }

    private void Update()
    {
        movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        if(movementInput.y != 0) verticalInput = Mathf.Sign(movementInput.y);
        else verticalInput = 0;
        if (movementInput.x != 0) horizontalInput = Mathf.Sign(movementInput.x);
        else horizontalInput = 0;
        animatorManager.UpdateAnimatorValues(horizontalInput, verticalInput);
    }


}
