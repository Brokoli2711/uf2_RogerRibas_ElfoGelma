using UnityEngine;

public class Talk_NPC : MonoBehaviour
{
    [SerializeField] public GameObject dialogueMark;
    [SerializeField] public GameObject dialogueUI;
    private bool isPlayerInRange;
    

    private void Update()
    {
        InputManager.OnInteraction += ShowUI;
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
        if (isPlayerInRange)
        {     
            dialogueUI.SetActive(true);
        }
            
    }
}
