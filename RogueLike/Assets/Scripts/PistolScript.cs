using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PistolScript : WeaponBehavior
{
    public float bulletSpeed;
    public GameObject bullet;
    public override void Fire()
    {
        if (this == null) return;

        if (secondsSinceLastShot >= secBeetweenShots)
        {

            for (int i = 0; i < numberBullets; i++)
            {
                GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
                BulletScript newBulletManager = newBullet.GetComponent<BulletScript>();
                newBulletManager.ShootBullet(inputManager.attackInput, bulletSpeed);

                secondsSinceLastShot = 0;
            }

        }
    }
}
