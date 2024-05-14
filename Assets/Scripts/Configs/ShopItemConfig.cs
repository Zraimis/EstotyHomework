using UnityEngine;

[CreateAssetMenu(fileName = "New StoreItem", menuName = "StoreItem")]
public class ShopConfig : ScriptableObject
{
    // TODO use private set properties for public fields which are set in the inspector better
    // example. [field: SerializeField] public Sprite MoneyIcon { get; private set; }
    public Sprite MoneyIcon;
    public int FirstBuyAmount;
    public int DefaultBuyAmount;
    public float BuyCost;
    public int Discount;
}