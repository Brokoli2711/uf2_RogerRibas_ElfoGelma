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

    public int speed = 5;
    public float totalhp = 3;
    public float hp;

   [SerializeField] private LifeBarScript lifeBar;
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
        hp = hp - damage;
        if (hp <= 0) SceneManager.LoadScene("Die");
    }
    private void Update()
    {
        ActionMove();
        if(lifeBar != null)
        {
            lifeBar.ChangeActualHp(hp);
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
        weapons[actualWeapon].gameObject.SetActive(false);
        actualWeapon++;
        if(actualWeapon >= weapons.Count) actualWeapon = 0;
        weapons[actualWeapon].gameObject.SetActive(true);
    }

}
