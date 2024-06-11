using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour
{
    public float speed;
    public float health;

    public Animator animator;

    public abstract void TakeDamage(float damage);
}
