using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        gameObject.SetActive(true);
    }

    void NextLine()
    {
        index++;
        textComponent.text = string.Empty;
        gameObject.GetComponent<AudioSource>().Stop();
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        if (index >= lines.Length)
        {
            index = 0;
        }

        foreach (char c in lines[index])
        {
            textComponent.text += c;
            if(index > 9 && index%2==0)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
