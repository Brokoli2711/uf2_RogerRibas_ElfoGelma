using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject room;
    [SerializeField] private int maxRooms = 15;
    [SerializeField] private int minRooms = 7;

    [SerializeField] public GameObject hatch;
    [SerializeField] public GameObject[] enemySpawners;

    public List<GameObject> roomList;
    int roomWidth = 20;
    int roomHeight = 12;

    int gridSizeX = 11;
    int gridSizeY = 11;

    private List<GameObject> roomObjects = new List<GameObject>();

    private Queue<Vector2Int> roomQueue = new Queue<Vector2Int>();

    private int[,] roomGrid;

    private int roomCount;

    private bool generationComplete = false;

    private void Start()
    {
        roomGrid = new int[gridSizeX, gridSizeY];
        roomQueue = new Queue<Vector2Int>();

        //Generation of the initial room on the center of the grid
        Vector2Int initialRoomIndex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
        StartRoomGenerationFromRoom(initialRoomIndex);

        Invoke("SpawnHatch", 2f);
        Invoke("SpawnEnemySpawner", 3f);
    }

    private void Update()
    {
        if(roomQueue.Count > 0 && roomCount < maxRooms && !generationComplete)
        {
            Vector2Int roomIndex = roomQueue.Dequeue();
            int gridX = roomIndex.x;
            int gridY = roomIndex.y;

            TryGenerateRoom(new Vector2Int(gridX - 1, gridY));
            TryGenerateRoom(new Vector2Int(gridX + 1, gridY));
            TryGenerateRoom(new Vector2Int(gridX, gridY - 1));
            TryGenerateRoom(new Vector2Int(gridX, gridY + 1));
        }
        else if(roomCount < minRooms)
        {
            Debug.Log("There are less rooms than we expected. Trying again");
            RegenerateRooms();
        }
        else if (!generationComplete)
        {
            Debug.Log($"Generation complete, {roomCount} rooms created");
            generationComplete = true;
        }
    }

    private void StartRoomGenerationFromRoom(Vector2Int roomIndex)
    {
        roomQueue.Enqueue(roomIndex);
        int x = roomIndex.x;
        int y = roomIndex.y;
        roomGrid[x, y] = 1;
        roomCount++;
        var initialRoom = Instantiate(room, GetPositionFromGridIndex(roomIndex),
            Quaternion.identity);
        initialRoom.name = $"Room-{roomCount}";
        initialRoom.GetComponent<Room>().RoomIndex = roomIndex;
        roomObjects.Add(initialRoom);

    }

    private bool TryGenerateRoom(Vector2Int roomIndex)
    {
        int x = roomIndex.x;
        int y = roomIndex.y;

        if(roomCount >= maxRooms ||
            //If a room is generated outside the bounds return false
            (x >= gridSizeX || y >= gridSizeY || x < 0 || y < 0) ||
            (Random.value < 0.5f && roomIndex != Vector2Int.zero) ||
            CountAdjacentRooms(roomIndex) > 1 ||
            (roomGrid[x, y] != 0)) return false;

        roomQueue.Enqueue(roomIndex);
        roomGrid[x, y] = 1;
        roomCount++;

        var newRoom = Instantiate(room, GetPositionFromGridIndex(roomIndex), Quaternion.identity);

        newRoom.GetComponent<Room>().RoomIndex = roomIndex;
        newRoom.name = $"Room-{roomCount}";
        roomObjects.Add(newRoom);

        OpenDoors(newRoom, x, y);

        return true;
    }

    //Regenerates all rooms and try generating again
    private void RegenerateRooms()
    {
        roomObjects.ForEach(Destroy);
        roomObjects.Clear();
        roomGrid = new int[gridSizeX, gridSizeY];
        roomQueue.Clear();
        roomCount = 0;
        generationComplete = false;

        Vector2Int initialRoomindex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
        StartRoomGenerationFromRoom(initialRoomindex);
    }

    private Vector3 GetPositionFromGridIndex(Vector2Int gridIndex)
    {
        int gridX = gridIndex.x;
        int gridY = gridIndex.y;
        return new Vector3(roomWidth * (gridX - gridSizeX / 2),
            roomHeight * (gridY - gridSizeY / 2));
    }

    void OpenDoors(GameObject room, int x, int y)
    {
        Room newRoomScript = room.GetComponent<Room>();

        //Neighbours
        Room leftRoomScript = GetRoomScriptAt(new Vector2Int(x - 1, y));
        Room rightRoomScript = GetRoomScriptAt(new Vector2Int(x + 1, y));
        Room topRoomScript = GetRoomScriptAt(new Vector2Int(x, y + 1));
        Room bottomRoomScript = GetRoomScriptAt(new Vector2Int(x, y - 1));

        //Determine which doors to open based on the direction
        if(x > 0 && roomGrid[x - 1, y] != 0)
        {
            //Left neighbour
            newRoomScript.OpenDoor(Vector2Int.left);
            leftRoomScript.OpenDoor(Vector2Int.right);
        }
        if(x < gridSizeX - 1 && roomGrid[x + 1, y] != 0)
        {
            //Right neighbour
            newRoomScript.OpenDoor(Vector2Int.right);
            rightRoomScript.OpenDoor(Vector2Int.left);
        }
        if(y > 0 && roomGrid[x, y -1] != 0)
        {
            //Down neighbour
            newRoomScript.OpenDoor(Vector2Int.down);
            bottomRoomScript.OpenDoor(Vector2Int.up);
        }
        if(y < gridSizeY - 1 && roomGrid[x, y + 1] != 0)
        {
            //Up neighbour
            newRoomScript.OpenDoor(Vector2Int.up);
            topRoomScript.OpenDoor(Vector2Int.down);
        }
    }

    Room GetRoomScriptAt(Vector2Int index) 
    {
        GameObject roomObject = roomObjects.Find( r => r.GetComponent<Room>().RoomIndex == index);
        if(roomObject != null) return roomObject.GetComponent<Room>();
        return null;
    }

    //This makes to not create too many rooms near one room
    private int CountAdjacentRooms(Vector2Int roomindex)
    {
        int x = roomindex.x;
        int y = roomindex.y;
        int count = 0;

        if (x > 0 && roomGrid[x - 1, y] != 0) count++; //Left Neighbour
        if (x < gridSizeX - 1 && roomGrid[x + 1, y] != 0) count++; //Right Neighbour
        if ( y > 0 && roomGrid[x, y - 1] != 0) count++; //Bottomn Neighbour
        if (y < gridSizeY - 1 && roomGrid[x, y + 1] != 0) count++; //Top Neighbour

        return count;
    }

    //Spawns the spawner for enemies
    void SpawnEnemySpawner()
    {
        for (int i = 1; i < roomList.Count - 1; i++)
        {
            Instantiate(enemySpawners[Random.Range(0, enemySpawners.Length)], roomList[i].transform.position, Quaternion.identity);

        }
    }

    //Spawns the hatch to finish the game
    void SpawnHatch()
    {
        //Aquí instanciamos la trampilla para pasar de nivel.
        Instantiate(hatch, roomList[roomList.Count - 1].transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Color gizmoColor = new Color(0, 1, 1, 0.05f);
        Gizmos.color = gizmoColor;

        for(int x = 0; x < gridSizeX; x++)
        {
            for(int y = 0; y < gridSizeY; y++)
            {
                Vector3 position = GetPositionFromGridIndex(new Vector2Int(x, y));
                Gizmos.DrawWireCube(position,
                    new Vector3(roomWidth, roomHeight, 1));
            }
        }
    }
}
