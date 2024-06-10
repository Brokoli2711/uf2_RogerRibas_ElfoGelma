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
        slider.maxValue = 3;
        slider.value = 3;
    }

    public void ChangeMaxHp(float totalhp)
    {
        if(slider != null)
        {
            slider.maxValue = totalhp;
        } 
    }

    public void ChangeActualHp(float hp)
    {
        if(slider != null)
        {
            slider.value = hp;
        }
        
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
