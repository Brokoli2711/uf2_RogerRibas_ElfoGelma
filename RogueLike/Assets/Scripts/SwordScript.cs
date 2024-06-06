using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : WeaponBehavior
{
    private BoxCollider2D boxCollider2d;
    public float damage = 2.5f;
    private PlayerController playerController;

    private void Start()
    {
        base.Start();
        boxCollider2d = GetComponent<BoxCollider2D>();
        transform.rotation = rotationQuaternion;
        playerController = GetComponentInParent<PlayerController>();
    }

    public override void Fire()
    {
        if (this == null) return;
        if (boxCollider2d != null)
        {
            if(this.gameObject.activeSelf) boxCollider2d.enabled = true;
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
            collision.gameObject.BroadcastMessage("TakeDamage", damage + playerController.damage);
        }
    }

    override public void MoveWeapon()
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

    override public void RotateWeapon()
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
