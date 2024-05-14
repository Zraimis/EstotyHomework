using UnityEngine;

namespace EstotyHomework.Configs
{
    [CreateAssetMenu(fileName = "New StoreItem", menuName = "StoreItem")]
    public class ShopConfig : ScriptableObject
    {
        public Sprite MoneyIcon;
        public int FirstBuyAmount;
        public int DefaultBuyAmount;
        public float BuyCost;
        public int Discount;
    }
}