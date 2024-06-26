using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float damage = 1f;

    private PlayerController playerController;
    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBullet());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //other.SendMessage("Hurt");
        if (!other.CompareTag("Player") && !other.CompareTag("Weapon") && !other.CompareTag("Seller") && !other.CompareTag("Arrow") && !other.CompareTag("Untagged"))
        {
            Debug.Log(other.gameObject.tag);
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.BroadcastMessage("TakeDamage", damage + playerController.damage);
        }
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
