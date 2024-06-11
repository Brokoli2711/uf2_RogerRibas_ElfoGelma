using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable objects/New Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public string description;
    public int baseCost;
}
