using UnityEngine;

namespace EstotyHomework.Configs
{
    [CreateAssetMenu(fileName = "New chest", menuName = "Chest")]
    public class ChestConfig : ScriptableObject
    {
        [field:SerializeField]
        public int MinMoney { get; private set; }
        [field:SerializeField]
        public int MaxMoney { get; private set; }
        [field:SerializeField]
        public int ActivityPointsToGet { get; private set; }
        [field:SerializeField]
        public Color Color{ get; private set; }
        [field:SerializeField]
        public int ID{ get; private set; }
    }
}