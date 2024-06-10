using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private InputManager inputM;
    private Rigidbody2D rb;
    [SerializeField] public List<GameObject> weapons;
    public int actualWeapon;

    private Vector2 movementValue;

    public int speed;
    [SerializeField] public float totalhp;
    [SerializeField] public float hp;

    [SerializeField] private LifeBarScript lifeBar;
    [SerializeField] private AudioSource audioSource;
    public float damage = 0;

    private void Start()
    {
        actualWeapon = 0;
        rb = GetComponent<Rigidbody2D>();
        inputM = GetComponent<InputManager>();
        lifeBar.InitializeLifeBar(totalhp);
        hp = totalhp;
    }

    public void DealDamage(int damage)
    {
        GetComponent<ParticleSystem>().Play();
        audioSource.Play();
        hp = hp - damage;
        lifeBar.ChangeActualHp(hp);
        if (hp <= 0) SceneManager.LoadScene("Die");
    }
    private void Update()
    {        
        ActionMove();
        if(lifeBar != null)
        {
            lifeBar.ChangeMaxHp(totalhp);
            lifeBar.ChangeNumber(hp, totalhp);
        }
        
    }

    private void OnEnable()
    {
        InputManager.OnSwap += SwapWeapons;
    }

    private void ActionMove()
    {
        movementValue = inputM.movementInput;

        rb.velocity = movementValue * speed;
    }

    private void SwapWeapons()
    {
        if (this == null) return;
        weapons[actualWeapon].gameObject.SetActive(false);
        actualWeapon++;
        if(actualWeapon >= weapons.Count) actualWeapon = 0;
        weapons[actualWeapon].gameObject.SetActive(true);
    }

}
