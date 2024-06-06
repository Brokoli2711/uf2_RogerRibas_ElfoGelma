using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int points;
    public TMP_Text pointsUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        points = PlayerPrefs.GetInt("currentPoints");
        pointsUI.text = "Points: " + points.ToString();
        LoadPanels();
        CheckPurchaseable();
    }


    public void AddPoints()
    {
        points += 100;
        pointsUI.text = "Points: " + points.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for(int i = 0;i < shopItemsSO.Length; i++)
        {
            if(points >= shopItemsSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
            else
            {
                myPurchaseBtns[i].interactable= false;
            }
        }
    }

    public void PurchaseItem(int numberBtn)
    {
        if(points >= shopItemsSO[numberBtn].baseCost)
        {
            points = points - shopItemsSO[(numberBtn)].baseCost;
            pointsUI.text = "Points: " + points.ToString();
            CheckPurchaseable();
        }
    }

    public void LoadPanels()
    {
        for(int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].nameTxt.text = shopItemsSO[i].name;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].priceTxt.text = shopItemsSO[i].baseCost.ToString();
        }
    }

    public void AddHP(float health)
    {
        playerController.hp += health;
    }

    public void AddDamage(float damage)
    {
        playerController.damage += damage;
    }
}
