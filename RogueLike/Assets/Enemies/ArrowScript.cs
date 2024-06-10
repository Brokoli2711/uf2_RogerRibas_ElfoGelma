using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        GetComponent<ParticleSystem>().Play();

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aplica daño al jugador (implementa el método TakeDamage en el script del jugador)
            collision.BroadcastMessage("DealDamage", 1);
            Destroy(gameObject); // Destruye el proyectil después de golpear al jugador
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destruye el proyectil si golpea un obstáculo
        }
    }
}