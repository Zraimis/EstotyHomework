using UnityEngine;

namespace EstotyHomework.Configs
{
    [CreateAssetMenu(fileName = "New card", menuName = "Card")]
    public class CardConfig : ScriptableObject
    {
        public Sprite logoSprite;
        public int activityPoints;
        public int currentAmount;
        public int maxAmount;
        public string cardTitle;
        public bool isClaimable;
    }
}