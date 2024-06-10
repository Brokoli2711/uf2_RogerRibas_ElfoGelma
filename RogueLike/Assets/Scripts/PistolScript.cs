using UnityEngine;

public class PistolScript : WeaponBehavior
{
    public float bulletSpeed;
    public GameObject bullet;

    private void Start()
    {
        base.Start();
        secondsSinceLastShot = secBeetweenShots;
        transform.rotation = rotationQuaternion;
    }

    private void Update()
    {
        base.Update();
        secondsSinceLastShot += Time.deltaTime;

    }
    public override void Fire()
    {
        if(this == null) return;

        if (secondsSinceLastShot >= secBeetweenShots)
        {

            for (int i = 0; i < numberBullets; i++)
            {
                GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
                audioSource.Play();

                BulletScript newBulletManager = newBullet.GetComponent<BulletScript>();
                newBulletManager.ShootBullet(inputManager.attackInput, bulletSpeed);

                secondsSinceLastShot = 0;
            }

        }
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
