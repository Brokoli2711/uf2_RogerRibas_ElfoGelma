using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private AnimatorManager animatorManager;

    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    public Vector2 attackInput;


    public static event Action OnAttack;
    public static event Action NotAttack;
    public static event Action OnInteraction;
    public static event Action OnSwap;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animatorManager = GetComponent<AnimatorManager>();
    }

    private void Update()
    {
        movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
        attackInput = playerInput.actions["Shoot"].ReadValue<Vector2>().normalized * 0.1f;
        playerInput.actions["Swap"].performed += CheckSwap;
        playerInput.actions["Interact"].performed += CheckInteraction;
        HandleMovementInput();
        CheckAttack();
    }

    private void HandleMovementInput()
    {
        if(movementInput.y != 0) verticalInput = Mathf.Sign(movementInput.y);
        else verticalInput = 0;
        if (movementInput.x != 0) horizontalInput = Mathf.Sign(movementInput.x);
        else horizontalInput = 0;
        animatorManager.UpdateAnimatorValues(horizontalInput, verticalInput);
    }

    private void CheckAttack()
    {
        if(attackInput != new Vector2(0,0))
        {
            OnAttack?.Invoke();
        }
        else NotAttack?.Invoke();
    }

    private void CheckInteraction(InputAction.CallbackContext ctx)
    {
        OnInteraction?.Invoke();
    }

    private void CheckSwap(InputAction.CallbackContext ctx)
    {
        OnSwap?.Invoke();
    }



}
