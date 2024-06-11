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
            // Aplica da�o al jugador (implementa el m�todo TakeDamage en el script del jugador)
            collision.BroadcastMessage("DealDamage", 1);
            Destroy(gameObject); // Destruye el proyectil despu�s de golpear al jugador
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destruye el proyectil si golpea un obst�culo
        }
    }
}