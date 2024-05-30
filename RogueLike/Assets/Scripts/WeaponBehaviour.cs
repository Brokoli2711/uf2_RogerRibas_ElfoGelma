using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class WeaponBehavior : MonoBehaviour
{
    public GameObject bullet;

    public float accuracy;
    public float numberBullets;

    public float secBeetweenShots;
    public float secondsSinceLastShot;


    public AudioSource audioSource;

    void Start()
    {
        secondsSinceLastShot = secBeetweenShots;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        secondsSinceLastShot += Time.deltaTime;

        InputManager.OnAttack += Fire;

    }


    public abstract void Fire();
}
