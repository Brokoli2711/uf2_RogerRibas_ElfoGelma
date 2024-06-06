using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerScript : MonoBehaviour
{
    [SerializeField] public GameObject dialogueMark;
    public GameObject shopUI;
    private bool isPlayerInRange;

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            InputManager.OnInteraction += ShowUI;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            shopUI.SetActive(false);
        }
    }

    private void ShowUI()
    {
        shopUI.SetActive(true);
    }
}
