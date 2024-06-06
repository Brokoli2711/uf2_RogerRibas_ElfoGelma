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

    public float interact;

    public static event Action OnAttack;
    public static event Action NotAttack;
    public static event Action OnInteraction;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animatorManager = GetComponent<AnimatorManager>();
    }

    private void Update()
    {
        movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
        attackInput = playerInput.actions["Shoot"].ReadValue<Vector2>().normalized * 0.1f;
        interact = playerInput.actions["Interact"].ReadValue<float>();
        Debug.Log(interact);
        HandleMovementInput();
        CheckAttack();
        CheckInteraction();
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

    private void CheckInteraction()
    {
        if(interact != 0) OnInteraction?.Invoke();
    }


}
