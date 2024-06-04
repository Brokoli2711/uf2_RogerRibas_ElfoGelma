using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawArrow : MonoBehaviour
{
    public GameObject projectilePrefab; //Prefab del proyectil
    public Transform firePoint; //Punto desde donde se disparan los proyectiles
    public float fireRate = 1f; //Tiempo entre disparos
    public float projectileSpeed = 10f; // Velocidad del proyectil

    private Transform player;
    private float nextFireTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // Instanciar el proyectil en el punto de disparo
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.tag = "arrow";

        // Calcular la dirección hacia el jugador
        Vector2 direction = (player.position - firePoint.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        // Orientar el proyectil hacia el jugador
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
