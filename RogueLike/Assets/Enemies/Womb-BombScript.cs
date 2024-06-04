using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WombBomb : MonoBehaviour
{
    public float speed = 5f;
    public float explosionRadius = 5f;
    public int health = 3;
    //public GameObject explosionEffect; // Efecto explosion
    public AudioClip explosionSound; // Sonido explosion


    public Animator wombAnimator;
    private Transform player;
    private bool isExploding = false;

    private void Awake()
    {
        wombAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        wombAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isExploding && player != null)
        {
            //Debug.Log("Entro en el if update");
            MoveTowardsPlayer();
        }
        else return;
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
        transform.position = newPosition;
        //Debug.Log("Yendo a "+ newPosition);


        // Checkea si puede explotar
        if (Vector3.Distance(transform.position, player.position) <= explosionRadius)
        {
            //Debug.Log("Me vengo");
            StartCoroutine(ExplodeCD());
        }
    }

    void Explode()
    {
        isExploding = true;
        Debug.Log("Exploding " + isExploding);
        //SonidoExplotar
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }
        // Check para player en la explosion
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D nearbyObject in colliders)
        {

            //Debug.Log(nearbyObject.name);
            if (nearbyObject.CompareTag("Player"))
            {
                nearbyObject.gameObject.BroadcastMessage("DealDamage", 2);
                Debug.Log(nearbyObject.name);
            }
        }
        Destroy(gameObject);
    }


    //Recibir daño
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            //TakeDamage(collision.GetComponent()); Funcion de recibir daño
            Destroy(collision.gameObject); // Destruir Bala
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Explode();
        }
    }

    IEnumerator ExplodeCD()
    {
        wombAnimator.SetTrigger("Explode");
        //Debug.Log("Corrutina");
        yield return new WaitForSeconds(1f);

        Explode();

    }
}