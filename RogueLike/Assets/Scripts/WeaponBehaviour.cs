using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class WeaponBehavior : MonoBehaviour
{
    public float numberBullets;
    public float secBeetweenShots;
    public float secondsSinceLastShot;
    public Quaternion rotationQuaternion;


    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public InputManager inputManager;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //audioSource = GetComponent<AudioSource>();
        inputManager = GetComponentInParent<InputManager>();
        transform.rotation = rotationQuaternion;
    }

    // Update is called once per frame
    public void Update()
    {
        if (inputManager != null)
        {
            InputManager.OnAttack += Fire;
            MoveWeapon();
            RotateWeapon();
        }

    }


    public abstract void MoveWeapon();  

    public abstract void RotateWeapon();


    public abstract void Fire();
}
