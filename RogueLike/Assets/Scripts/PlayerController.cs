using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputManager inputM;
    private Rigidbody2D rb;

    private Vector2 movementValue;

    public int speed = 5;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputM = GetComponent<InputManager>();
    }

    private void Update()
    {
        ActionMove();
    }

    private void ActionMove()
    {
        movementValue = inputM.movementInput;

        rb.velocity = movementValue * speed;
    }

}
