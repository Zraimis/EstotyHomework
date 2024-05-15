using UnityEngine;

namespace EstotyHomework.Configs
{
    [CreateAssetMenu(fileName = "New card", menuName = "Card")]
    public class CardConfig : ScriptableObject
    {
        [field:SerializeField]
        public Sprite LogoSprite { get; private set; }
        [field:SerializeField]
        public int ActivityPoints { get; private set; }
        [field:SerializeField]
        public int CurrentAmount { get; private set; }
        [field:SerializeField]
        public int MaxAmount { get; private set; }
        [field:SerializeField]
        public string CardTitle { get; private set; }
        [field:SerializeField]
        public bool IsClaimable { get; private set; }
    }
}