using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarScript : MonoBehaviour
{
    private Slider slider;
    public TMP_Text hpUI;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeMaxHp(float totalhp)
    {
        slider.maxValue = totalhp;
    }

    public void ChangeActualHp(float hp)
    {
        slider.value = hp;
    }

    public void InitializeLifeBar(float maxHp)
    {
        ChangeMaxHp(maxHp);
        ChangeActualHp(maxHp);
    }

    public void ChangeNumber(float hp, float totalhp)
    {
        hpUI.text = hp + "/" + totalhp;
    }
}
