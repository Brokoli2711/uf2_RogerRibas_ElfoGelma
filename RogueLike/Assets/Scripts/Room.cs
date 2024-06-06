using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject topDoor;
    [SerializeField] private GameObject bottomDoor;
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    public Vector2Int RoomIndex {  get; set; }

    public void OpenDoor(Vector2Int direction)
    {
        if(direction == Vector2Int.up) topDoor.SetActive(true);
        else if (direction == Vector2Int.down) bottomDoor.SetActive(true);
        else if (direction == Vector2Int.left) leftDoor.SetActive(true);
        else if (direction == Vector2Int.right) rightDoor.SetActive(true);
    }

    private void Update()
    {
        //EnemySpawn.IsEnemy += CloseDoors;
        //EnemySpawn.IsNotEnemy += OpenDoors;
    }


    public void OpenDoors()
    {
        if (topDoor != null)
        {
            topDoor.GetComponent<BoxCollider2D>().enabled = true;
            Paint(topDoor, Color.green);
        }
        if (bottomDoor != null)
        {
            bottomDoor.GetComponent<BoxCollider2D>().enabled = true;
            Paint(bottomDoor, Color.green);
        }
        if (leftDoor != null)
        {
            leftDoor.GetComponent<BoxCollider2D>().enabled = true;
            Paint(leftDoor, Color.green);
        }
        if (rightDoor != null)
        {
            rightDoor.GetComponent<BoxCollider2D>().enabled = true;
            Paint(rightDoor, Color.green);
        }
    }

    public void CloseDoors()
    {
        if (topDoor != null)
        {
            topDoor.GetComponent<BoxCollider2D>().enabled = false;
            Paint(topDoor, Color.black);
        }
        if (bottomDoor != null)
        {
            bottomDoor.GetComponent<BoxCollider2D>().enabled = false;
            Paint(bottomDoor, Color.black);
        }
        if (leftDoor != null)
        {
            leftDoor.GetComponent<BoxCollider2D>().enabled = false;
            Paint(leftDoor, Color.black);
        }
        if (rightDoor != null)
        {
            rightDoor.GetComponent<BoxCollider2D>().enabled = false;
            Paint(rightDoor, Color.black);
        }
    }

    private void Paint(GameObject door, Color color)
    {
        door.GetComponent<SpriteRenderer>().material.color = color;
    }

}
