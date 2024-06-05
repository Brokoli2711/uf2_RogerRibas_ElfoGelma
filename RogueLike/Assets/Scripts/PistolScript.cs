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
        secondsSinceLastShot = secBeetweenShots;
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputManager = GetComponentInParent<InputManager>();
        transform.rotation = rotationQuaternion;
    }

    private void Update()
    {
        secondsSinceLastShot += Time.deltaTime;
        InputManager.OnAttack += Fire;
        MoveWeapon();
        RotateWeapon();

    }
    public override void Fire()
    {
        if(this == null) return;

        if (secondsSinceLastShot >= secBeetweenShots)
        {

            for (int i = 0; i < numberBullets; i++)
            {
                GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);


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
            posX = 0.15f;
        }
        else if (inputManager.attackInput.x < 0)
        {
            posX = -0.15f;
        }
        else if (inputManager.attackInput.y > 0)
        {
            posY = 0.25f;
            posX = 0.08f;
        }
        else if (inputManager.attackInput.y < 0)
        {
            posY = -0.1f;
            posX = -0.1f;
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
            transform.rotation = Quaternion.Euler(0, 0, temporalRotation.z);
        }
        else if (inputManager.attackInput.y > 0)
        {
            temporalRotation.z = 90;
            transform.rotation = Quaternion.Euler(0,0, temporalRotation.z);
        }
        else
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
            transform.rotation = rotationQuaternion;
        }



    }
}
