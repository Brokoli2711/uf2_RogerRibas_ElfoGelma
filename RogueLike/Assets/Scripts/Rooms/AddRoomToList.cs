using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoomToList : MonoBehaviour
{

    private RoomManager roomTemplates;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(SaveFloor());
    }

    IEnumerator SaveFloor()
    {
        yield return new WaitForSeconds(0.5f);
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomManager>();
        roomTemplates.roomList.Add(this.gameObject);
    }

}
