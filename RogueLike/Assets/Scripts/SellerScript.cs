using UnityEngine;

public class SellerScript : MonoBehaviour
{
    [SerializeField] public GameObject dialogueMark;
    [SerializeField] public GameObject shopUI;
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
            shopUI.SetActive(false);
        }
    }

    private void ShowUI()
    {
        if (isPlayerInRange && this.gameObject != null)
            shopUI.SetActive(true);
    }
}
