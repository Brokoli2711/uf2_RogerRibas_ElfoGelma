using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void Begin()
    {
        SceneManager.LoadScene("RoomGenerator");
    }
}
