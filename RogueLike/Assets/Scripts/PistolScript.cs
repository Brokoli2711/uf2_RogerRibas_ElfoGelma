using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
                GameObject newBullet;
                if (inputManager.attackInput.x < 0) newBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 0.4f), transform.rotation);
                else newBullet = Instantiate(bullet, transform.position, transform.rotation);


                BulletScript newBulletManager = newBullet.GetComponent<BulletScript>();
                newBulletManager.ShootBullet(inputManager.attackInput, bulletSpeed);

                secondsSinceLastShot = 0;
            }

        }
    }
}
