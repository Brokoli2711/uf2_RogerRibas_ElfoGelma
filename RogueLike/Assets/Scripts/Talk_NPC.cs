using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_NPC : MonoBehaviour
{
    [SerializeField] public GameObject dialogueMark;
    [SerializeField] public GameObject dialogueUI;
    private bool isPlayerInRange;
    
    
    void Start()
    {
        
    }

    private void Update()
    {
        if (isPlayerInRange) InputManager.OnInteraction += ShowUI;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            dialogueUI.SetActive(false);
        }
    }

    private void ShowUI()
    {
        dialogueUI.SetActive(true);
    }
}
