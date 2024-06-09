using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : WeaponBehavior
{
    public ParticleSystem fireParticles;
    public float damage = 0.1f;
    public float fuelConsumptionRate; // La cantidad de combustible consumido por segundo

    private bool isFiring;

    private void Start()
    {
        base.Start();
        isFiring = false;
        fireParticles.Stop();
    }

    public override void Fire()
    {
        if (numberBullets > 0)
        {
            if (!isFiring)
            {
                isFiring = true;
                fireParticles.Play();
                //audioSource.Play();
            }

            //if (numberBullets <= 0)
            //{
            //    StopFiring();
            //    StartCoroutine(Recharge());
            //}
        }
    }
    private void OnEnable()
    {
        InputManager.NotAttack += NotAttacking;
    }

    private void NotAttacking()
    {
        StopFiring();
    }

    void StopFiring()
    {
        isFiring = false;
        fireParticles.Stop();
        //audioSource.Stop();
    }

    override public void MoveWeapon()
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

    override public void RotateWeapon()
    {
        Quaternion temporalRotation = rotationQuaternion;

        if (inputManager.attackInput.x < 0)
        {
            temporalRotation.z = 180;
            spriteRenderer.flipY = true;
            transform.rotation = Quaternion.Euler(0,0, temporalRotation.z);
        }
        else if (inputManager.attackInput.y < 0)
        {
            temporalRotation.z = 270;
            spriteRenderer.flipY = false;
            transform.rotation = Quaternion.Euler(0, 0, temporalRotation.z);
        }
        else if (inputManager.attackInput.y > 0)
        {
            temporalRotation.z = 90;
            spriteRenderer.flipY = false;
            transform.rotation = Quaternion.Euler(0, 0, temporalRotation.z);
        }
        else
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
            transform.rotation = rotationQuaternion;
        }

    }

    //IEnumerator Recharge()
    //{
    //    yield return new WaitForSeconds(3f);

    //    numberBullets = 10000;

    //}
}
