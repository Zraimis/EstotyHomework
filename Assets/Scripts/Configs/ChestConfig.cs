using UnityEngine;

namespace EstotyHomework.Configs
{
    [CreateAssetMenu(fileName = "New chest", menuName = "Chest")]
    public class ChestConfig : ScriptableObject
    {
        public int minMoney;
        public int maxMoney;
        public int activityPointsToGet;
        public Color color;
        public int id;
    }
}