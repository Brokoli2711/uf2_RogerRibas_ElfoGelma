using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : WeaponBehavior
{
    public float bulletSpeed;
    public override void Fire()
    {
        Vector2 targetPosition = Input.mousePosition;

        if (secondsSinceLastShot >= secBeetweenShots)
        {

            for (int i = 0; i < numberBullets; i++)
            {
                GameObject newBullet = Instantiate(bullet, transform.position + transform.forward * bulletSpeed, transform.rotation);

                newBullet.transform.LookAt(targetPosition);
                secondsSinceLastShot = 0;
            }

        }
    }
}
