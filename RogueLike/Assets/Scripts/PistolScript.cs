using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PistolScript : WeaponBehavior
{
    private SpriteRenderer spriteRenderer;
    public Quaternion rotationQuaternion;
    public float bulletSpeed;
    public GameObject bullet;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputManager = GetComponentInParent<InputManager>();
        transform.rotation = rotationQuaternion;
    }

    private void Update()
    {
        MoveWeapon();
        RotateWeapon();
    }
    public override void Fire()
    {
        if (this == null) return;

        if (secondsSinceLastShot >= secBeetweenShots)
        {

            for (int i = 0; i < numberBullets; i++)
            {
                GameObject newBullet;
                if (inputManager.attackInput.x < 0) newBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 0.4f), transform.rotation);
                else newBullet = Instantiate(bullet, transform.position, transform.rotation);


                BulletScript newBulletManager = newBullet.GetComponent<BulletScript>();
                newBulletManager.ShootBullet(inputManager.attackInput, bulletSpeed);

                secondsSinceLastShot = 0;
            }

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
        Quaternion temporalRotation = rotationQuaternion;

        if (inputManager.attackInput.x < 0)
        {
            spriteRenderer.flipY = false;
            spriteRenderer.flipX = true;
            transform.rotation = rotationQuaternion;
        }
        else if (inputManager.attackInput.y < 0)
        {
            temporalRotation.z = 270;
            transform.rotation = temporalRotation;
        }
        else if (inputManager.attackInput.y > 0)
        {
            temporalRotation.z = 90;
            transform.rotation = temporalRotation;
        }
        else
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
            transform.rotation = rotationQuaternion;
        }



    }
}
