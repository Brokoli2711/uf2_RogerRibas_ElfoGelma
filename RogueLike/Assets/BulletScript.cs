using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBullet());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //other.SendMessage("Hurt");
        if (!other.CompareTag("Player") && !other.CompareTag("Weapon")) Destroy(gameObject);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public void ShootBullet(Vector2 direction, float bulletSpeed)
    {
        rb.velocity = direction * bulletSpeed;
    }

}
