using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour
{
    public float speed;
    public float health;

    public Animator animator;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(collision.GetComponent<BulletScript>().damage); //Funcion de recibir daño
            Destroy(collision.gameObject); // Destruir Bala
        }
        else if (collision.CompareTag("Sword")){
            TakeDamage(collision.GetComponent<SwordScript>().damage);
        }
    }

    public abstract void TakeDamage(float damage);
}
