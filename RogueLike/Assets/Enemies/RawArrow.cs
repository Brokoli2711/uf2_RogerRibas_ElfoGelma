using UnityEngine;

public class StationaryShooter : EnemyScript
{
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    public float projectileSpeed = 10f;
    private SpriteRenderer spriteRenderer;
    private Transform player;
    [SerializeField] private AudioSource audioSource;
    private float nextFireTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player != null)
        {
            if (player.position.x < transform.position.x)
            {
                spriteRenderer.flipX = false; 
            }
            else
            {
                spriteRenderer.flipX = true; 
            }

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot()
    {
        Vector2 targetPosition = player.position;
        Vector2 shooterPosition = transform.position;
        Vector2 direction = (targetPosition - shooterPosition).normalized;

        GameObject projectile = Instantiate(projectilePrefab, shooterPosition, Quaternion.identity);
        audioSource.Play();
        projectile.tag = "Arrow";

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    override public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}