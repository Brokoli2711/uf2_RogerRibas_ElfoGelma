using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoom : MonoBehaviour
{
    public Camera camera;
    public GameObject spawn;
    public GameObject cameraSpawn;

    private void Start()
    {
        camera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camera.transform.position = new Vector3(cameraSpawn.transform.position.x, cameraSpawn.transform.position.y, -10);
            collision.gameObject.transform.position = spawn.transform.position;
        }
    }
}
