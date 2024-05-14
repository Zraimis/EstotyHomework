using UnityEngine;

[CreateAssetMenu(fileName = "New chest", menuName = "Chest")]
public class ChestConfig : ScriptableObject
{
    // TODO use private set properties for public fields which are set in the inspector better
    // example. [field: SerializeField] public Sprite MoneyIcon { get; private set; }
    public int minMoney;
    public int maxMoney;
    public int activityPointsToGet;
    public Color color;
    public int id;
}
