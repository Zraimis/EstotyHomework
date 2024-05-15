using UnityEngine;

namespace EstotyHomework.Configs
{
    [CreateAssetMenu(fileName = "New StoreItem", menuName = "StoreItem")]
    public class ShopConfig : ScriptableObject
    {
        [field:SerializeField]
        public Sprite MoneyIcon { get; private set; }
        [field:SerializeField]
        public int FirstBuyAmount { get; private set; }
        [field:SerializeField]
        public int DefaultBuyAmount { get; private set; }
        [field:SerializeField]
        public float BuyCost { get; private set; }
        [field:SerializeField]
        public int Discount { get; private set; }
    }
}