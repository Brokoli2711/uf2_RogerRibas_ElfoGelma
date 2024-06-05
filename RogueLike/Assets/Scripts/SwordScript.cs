using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : WeaponBehavior
{
    private BoxCollider2D boxCollider2d;
    private SpriteRenderer spriteRenderer;
    public float damage = 2.5f;
    public Quaternion rotationQuaternion;

    private void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputManager = GetComponentInParent<InputManager>();
        transform.rotation = rotationQuaternion;
    }

    private void Update()
    {
        if(inputManager != null)
        {
            InputManager.OnAttack += Fire;
            MoveWeapon();
            RotateWeapon();
        }
        
    }

    public override void Fire()
    {
        if (boxCollider2d != null)
        {
            boxCollider2d.enabled = true;
        } 
    }

    private void OnEnable()
    {
        InputManager.NotAttack += NotAttacking;
    }

    private void NotAttacking()
    {
        if (boxCollider2d != null) boxCollider2d.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.BroadcastMessage("TakeDamage", damage);
        }
    }

    private void MoveWeapon()
    {
        float posX = 0;
        float posY = 0;

        if (inputManager.attackInput.x > 0)
        {
            posX = 0.1f;
        }
        else if (inputManager.attackInput.x < 0)
        {
            posX = -0.1f;
            posY = 0.1f;
        }
        else if (inputManager.attackInput.y > 0)
        {
            posY = 0.2f;
            posX = -0.05f;
        }
        else if (inputManager.attackInput.y < 0)
        {
            posY = -0.05f;
            posX = 0.05f;
        }

        transform.localPosition = new Vector2(posX, posY);

    }

    private void RotateWeapon()
    {

        if (inputManager.attackInput.x < 0)
        {
            spriteRenderer.flipY = true;
            spriteRenderer.flipX = true;
        }
        else if (inputManager.attackInput.y < 0)
        {
            spriteRenderer.flipY = true;
            spriteRenderer.flipX = false;
        }
        else if (inputManager.attackInput.y > 0)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = false;
        }
        else
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
        }



    }
}
