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

        Vector2 targetPosition = Input.mousePosition;

        if (secondsSinceLastShot >= secBeetweenShots)
        {

            for (int i = 0; i < numberBullets; i++)
            {
                //GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
                GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

                newBullet.transform.LookAt(targetPosition);
                secondsSinceLastShot = 0;
            }

        }
    }
}
