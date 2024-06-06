using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public int enemiesDefeated;
    public static event Action IsEnemy;
    public static event Action IsNotEnemy;

    private void Start()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
        enemiesDefeated = 0;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hola");
            foreach (GameObject e in enemies)
            {
                e.SetActive(true);
            }
        }
    }

    private void CheckEnemies()
    {
        if(enemies.Length == enemiesDefeated)
        {
            IsNotEnemy?.Invoke();
        }
    }
}
