using UnityEngine;

[CreateAssetMenu(fileName = "New chest", menuName = "Chest")]
public class ChestConfig : ScriptableObject
{
    public int minMoney;
    public int maxMoney;
    public int activityPointsToGet;
    public Color color;
}
